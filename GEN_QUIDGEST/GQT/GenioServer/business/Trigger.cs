using CSGenio.core.ai;
using CSGenio.framework;
using CSGenio.persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSGenio.business.Triggers
{
	/// <summary>
	/// Interface of a generic trigger
	/// </summary>
	public interface ITrigger
	{
		/// <summary>
		/// Gets the action with the provided order
		/// within the context of the trigger's action flow.
		/// </summary>
		/// <param name="num">The position of the action in the action flow.</param>
		/// <returns>An action</returns>
		IAction GetAction(int order);

		/// <summary>
		/// Adds the provided action to the trigger's action flow.
		/// </summary>
		/// <param name="order">The order of the action in the context of the action flow.</param>
		/// <param name="action">The action to add to the action flow.</param>
		void AddAction(int order,IAction action);

		/// <summary>
		/// Executes the provided action.
		/// </summary>
		/// <param name="action">The action to execute.</param>
		void ExecuteAction(IAction action);

		/// <summary>
		/// Executes the trigger's action flow.
		/// </summary>
		void ExecuteActions();
	}

	/// <summary>
	/// A generic trigger
	/// </summary>
	public abstract class Trigger : ITrigger
	{
		/// <summary>
		/// The trigger identifier
		/// </summary>
		protected string _id;

		/// <summary>
		/// The actions of the trigger
		/// </summary>
		private readonly Dictionary<int, IAction> _actions;

		/// <summary>
		/// The context of the trigger
		/// </summary>
		private readonly TriggerContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="Trigger" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		protected Trigger(TriggerContext context)
		{
			_actions = new Dictionary<int, IAction>();
			_context = context;
		}

		/// <summary>
		/// Checks the permissions.
		/// </summary>
		/// <returns></returns>
		private bool CheckPermissions()
		{
			if (_context == null || _context.MinimumRole == null)
				return true;
			return _context.User.VerifyAccess(_context.MinimumRole);
		}

		/// <summary>
		/// Verifies the condition.
		/// </summary>
		/// <returns></returns>
		private bool VerifyCondition()
		{
			if (_context == null || _context.Condition == null)
				return true;
			return _context.Condition.ExecuteCondition(_context.Area, _context.PersistentSupport, FunctionType.ALT);
		}

		/// <summary>
		/// Executes the provided actions.
		/// </summary>
		/// <param name="actions">The actions.</param>
		/// <exception cref="CSGenio.business.BusinessException">Trigger.ExecuteActions</exception>
		private void ExecuteActionsInternal(IEnumerable<IAction> actions)
		{
			if (CheckPermissions() && VerifyCondition())
			{
				// Execute the actions
				foreach (IAction action in actions)
					action.Execute();

				// Apply the changes
				foreach (var area in _context.DirtyRows.Keys)
				{
					/*
						It is necessary to update if:
						(1)	the affected area is different from the one
							that triggered the action
						(2)	the affected area is the one that triggered the action
							and the action is executed after the main event
					*/
					if (!IsRedundantUpdate(area))
					{
						foreach (var row in _context.DirtyRows[area].Values)
							row.update(_context.PersistentSupport);
					}
				}
			}
		}

		/// <summary>
		/// Determines whether immediately updating the specific area
		/// would be redundant.
		/// </summary>
		/// <param name="area">The area.</param>
		/// <returns>
		///   <c>true</c> if redundant; otherwise, <c>false</c>.
		/// </returns>
		private bool IsRedundantUpdate(string area)
		{
			return _context.Area.Alias == area && _context.Moment == TriggerContext.TriggerMoment.BEFORE;
		}

		public IAction GetAction(int order)
		{
			return _actions[order];
		}

		public void AddAction(int order, IAction action)
		{
			_actions.Add(order, action);
		}

		public void ExecuteAction(IAction action)
		{
			ExecuteActionsInternal(new List<IAction>() { action });
		}

		public void ExecuteActions()
		{
			IEnumerable<IAction> actions = _actions
				.OrderBy(entry => entry.Key)
				.Select(entry => entry.Value);

			ExecuteActionsInternal(actions);
		}
	}

	/// <summary>
	/// Context to triggers and actions
	/// </summary>
	public class TriggerContext
	{
		public enum TriggerMoment { BEFORE, AFTER };
		public enum TriggerEvent { INSERT, UPDATE, ELIMINATE, DUPLICATE };

		/// <summary>
		/// Gets or sets the area.
		/// </summary>
		/// <value>
		/// The area.
		/// </value>
		public DbArea Area { get; set; }

		/// <summary>
		/// Gets or sets the old values.
		/// </summary>
		/// <value>
		/// The old values.
		/// </value>
		public Area OldValues { get; set; }

		/// <summary>
		/// Gets or sets the persistent support.
		/// </summary>
		/// <value>
		/// The persistent support.
		/// </value>
		public PersistentSupport PersistentSupport { get; set; }

		/// <summary>
		/// Gets or sets the condition.
		/// </summary>
		/// <value>
		/// The condition.
		/// </value>
		public ConditionFormula Condition { get; set; }

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		/// <value>
		/// The user.
		/// </value>
		public User User { get; set; }

		/// <summary>
		/// Gets or sets the minimum role.
		/// </summary>
		/// <value>
		/// The minimum role.
		/// </value>
		public Role MinimumRole { get; set; }

		/// <summary>
		/// Gets or sets the trigger moment.
		/// </summary>
		/// <value>
		/// The moment.
		/// </value>
		public TriggerMoment? Moment { get; set; }

		/// <summary>
		/// Gets or sets the trigger event.
		/// </summary>
		/// <value>
		/// The event.
		/// </value>
		public TriggerEvent? Event { get; set; }

		/// <summary>
		/// Gets or sets the dirty rows.
		/// </summary>
		/// <value>
		/// The dirty rows.
		/// </value>
		public Dictionary<string, Dictionary<string, DbArea>> DirtyRows { get; }
			= new Dictionary<string, Dictionary<string, DbArea>>();

	}

	/// <summary>
	/// Trigger TEST1
	/// </summary>
	/// <seealso cref="CSGenio.business.Trigger" />
	public class TriggerTest1 : Trigger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerTest1" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TriggerTest1(TriggerContext context) : base(context)
		{
			_id = "TEST1";

			List<ByAreaArguments> argumentsListByArea;

			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"apiurl"}, new int[] {0}, "glob", ""));
			context.Condition = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return !(((string)args[0]) == "");
			});

			// Actions
			InternalOperationFormula formula;

			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"designat"}, new int[] {0}, "cmpny", "codempre"));
			formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])+".";
			});

			AddAction(1, new UpdateFieldValueAction(context, "cmpny", "designat", formula, false));

			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"photogra"}, new int[] {0}, "pesso", "codpesso"));
			formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((byte[])args[0]);
			});

			AddAction(2, new UpdateFieldValueAction(context, "glob", "legend", formula, false));
		}
	}

	/// <summary>
	/// Trigger TRIGMENU2
	/// </summary>
	/// <seealso cref="CSGenio.business.Trigger" />
	public class TriggerTrigmenu2 : Trigger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerTrigmenu2" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TriggerTrigmenu2(TriggerContext context) : base(context)
		{
			_id = "TRIGMENU2";

			// Actions
			List<ByAreaArguments> argumentsListByArea;
			InternalOperationFormula formula;

			argumentsListByArea = new List<ByAreaArguments>();
			formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return "Teste do trigger";
			});

			AddAction(1, new UpdateFieldValueAction(context, "expen", "descript", formula, false));
		}
	}

	/// <summary>
	/// Trigger EMPTYDESCRIPTION
	/// </summary>
	/// <seealso cref="CSGenio.business.Trigger" />
	public class TriggerEmptydescription : Trigger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerEmptydescription" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TriggerEmptydescription(TriggerContext context) : base(context)
		{
			_id = "EMPTYDESCRIPTION";

			// Actions
			List<ByAreaArguments> argumentsListByArea;
			InternalOperationFormula formula;

			argumentsListByArea = new List<ByAreaArguments>();
			formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return "";
			});

			AddAction(1, new UpdateFieldValueAction(context, "expen", "descript", formula, false));
		}
	}

	/// <summary>
	/// Trigger FILLDESCRIPTION
	/// </summary>
	/// <seealso cref="CSGenio.business.Trigger" />
	public class TriggerFilldescription : Trigger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerFilldescription" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TriggerFilldescription(TriggerContext context) : base(context)
		{
			_id = "FILLDESCRIPTION";

			// Actions
			List<ByAreaArguments> argumentsListByArea;
			InternalOperationFormula formula;

			argumentsListByArea = new List<ByAreaArguments>();
			formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return "Teste do trigger";
			});

			AddAction(1, new UpdateFieldValueAction(context, "expen", "descript", formula, false));
		}
	}

	/// <summary>
	/// Trigger MENUTRIGER
	/// </summary>
	/// <seealso cref="CSGenio.business.Trigger" />
	public class TriggerMenutriger : Trigger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerMenutriger" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TriggerMenutriger(TriggerContext context) : base(context)
		{
			_id = "MENUTRIGER";

			// Actions
			List<ByAreaArguments> argumentsListByArea;
			InternalOperationFormula formula;

			argumentsListByArea = new List<ByAreaArguments>();
			formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return "Teste do trigger";
			});

			AddAction(1, new UpdateFieldValueAction(context, "expen", "descript", formula, false));
		}
	}

	/// <summary>
	/// Trigger EMPTYDESCRIPTIO2
	/// </summary>
	/// <seealso cref="CSGenio.business.Trigger" />
	public class TriggerEmptydescriptio2 : Trigger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerEmptydescriptio2" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TriggerEmptydescriptio2(TriggerContext context) : base(context)
		{
			_id = "EMPTYDESCRIPTIO2";

			// Actions
			List<ByAreaArguments> argumentsListByArea;
			InternalOperationFormula formula;

			argumentsListByArea = new List<ByAreaArguments>();
			formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return "";
			});

			AddAction(1, new UpdateFieldValueAction(context, "expen", "descript", formula, false));
		}
	}

	/// <summary>
	/// Trigger FILLDESCRIPTION2
	/// </summary>
	/// <seealso cref="CSGenio.business.Trigger" />
	public class TriggerFilldescription2 : Trigger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerFilldescription2" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TriggerFilldescription2(TriggerContext context) : base(context)
		{
			_id = "FILLDESCRIPTION2";

			// Actions
			List<ByAreaArguments> argumentsListByArea;
			InternalOperationFormula formula;

			argumentsListByArea = new List<ByAreaArguments>();
			formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return "Teste do trigger";
			});

			AddAction(1, new UpdateFieldValueAction(context, "expen", "descript", formula, false));
		}
	}
}
