/*
[APM] 30-04-2021: CUSTOMIZED VERSION

jQuery.wizard v1.1.3
https://github.com/kflorence/jquery-wizard/
An asynchronous form wizard that supports branching.

Requires:
 - jQuery 1.6.0+
 - jQuery UI widget 1.9.0+

Copyright (c) 2017 Kyle Florence
Dual licensed under the MIT and GPLv2 licenses.
*/

(function( $, undefined ) {

	var count = 0,
		selector = {},
		className = {},

		// Reference to commonly used methods
		aps = Array.prototype.slice,

		// Used to normalize function arguments that can be either
		// an array of values or a single value
		arr = function( obj ) {
			return $.isArray( obj ) ? obj : [ obj ];
		},

		// Commonly used strings
		id = "id",
		form = "form",
		click = "click",
		submit = "submit",
		disabled = "disabled",
		namespace = "kf-wizard",
		wizard = "wizard",

		def = "default",
		num = "number",
		obj = "object",
		str = "string",
		bool = "boolean",

		// Events
		afterBackward = "afterBackward",
		afterDestroy = "afterDestroy",
		afterForward = "afterForward",
		afterSelect = "afterSelect",
		afterSave = "afterSave",
		beforeBackward = "beforeBackward",
		beforeDestroy = "beforeDestroy",
		beforeForward = "beforeForward",
		beforeSelect = "beforeSelect",
		beforeSave = "beforeSave",
		onCreate = "onCreate"

	// Generate selectors and class names for common wizard elements
	$.each( "branch form header step wrapper".split( " " ), function() {
		selector[ this ] = "." + ( className[ this ] = wizard + "-" + this );
	});

	$.widget( "kf." + wizard, {
		version: "1.1.3",
		options: {
			animations: {
				show: {
					options: {
						duration: 0
					},
					properties: {
						opacity: "show"
					}
				},
				hide: {
					options: {
						duration: 0
					},
					properties: {
						opacity: "hide"
					}
				}
			},
			backward: ".backward",
			branches: ".branch",
			disabled: false,
			enableSubmit: true,
			forward: ".forward",
			header: ":header:first",
			initialStep: 0,
			stateAttribute: "data-state",
			stepClasses: {
				current: "current",
				exclude: "exclude",
				stop: "stop",
				submit: "submit",
				unidirectional: "unidirectional"
			},
			steps: ".step",
			submit: ":submit",
			transitions: {},
			unidirectional: false,

			/* callbacks */
			afterBackward: null,
			afterDestroy: null,
			afterForward: null,
			afterSelect: null,
			afterSave: null,
			beforeBackward: null,
			beforeDestroy: null,
			beforeForward: null,
			beforeSelect: null,
			beforeSave: null
		},

		_create: function () {
			// [APM] Added a function to init custom properties.
			this.initConfig();

			var $form, $header,
				self = this,
				o = self.options,
				$element = self.element,
				$steps = $element.find( o.steps ),
				$stepsWrapper = $steps.eq(0).parent();

			if ( $element[ 0 ].elements ) {
				$form = $element;

			// If element isn't form, look inside and outside element
			} else if ( !( $form = $element.find( form ) ).length ) {
				$form = $element.closest( form );
			}

			// [APM] FIX: In show mode there's no <form> tag, so we try to find it's container.
			if ($form.length === 0)
				$form = $element.closest('#formContainer');

			// If header isn't found in element, look in form scope
			if ( !( $header = $element.find( o.header ) ).length ) {
				$header = $form.find(this.config.wizardId).find( o.header );
			}

			self.elements = {
				form: $form.addClass( className.form ),
				submit: $form.find(this.config.wizardId).find( o.submit ),
				forward: $form.find(this.config.wizardId).find( o.forward ),
				backward: $form.find(this.config.wizardId).find( o.backward ),
				header: $header.addClass( className.header ),
				steps: $element.find( o.steps ).hide().addClass( className.step ),
				branches: $element.find( o.branches ).add( $stepsWrapper ).addClass( className.branch ),
				stepsWrapper: $stepsWrapper.addClass( className.wrapper ),
				wizard: $element.addClass( wizard )
			};

			if ( !$stepsWrapper.attr( id ) ) {

				// stepsWrapper must have an ID as it also functions as the default branch
				$stepsWrapper.attr( id, wizard + "-" + ( ++count ) );
			}

			self.elements.forward.on( "click." + namespace, function( event ) {
				event.preventDefault();
				self.forward( event );
			});

			self.elements.backward.on( "click." + namespace, function( event ) {
				event.preventDefault();
				self.backward( event );
			});

			self._currentState = {
				branchesActivated: [],
				stepsActivated: []
			};

			self._stepCount = self.elements.steps.length;
			self._lastStepIndex = self._stepCount - 1;

			// Cache branch labels for quick access later
			self._branchLabels = [];
			self.elements.steps.each(function( i ) {
				self._branchLabels[ i ] = $( this ).parent().attr( id );
			});

			// Called in the context of jQuery's .filter() method in _state()
			self._excludesFilter = function() {
				return !$( this ).hasClass( o.stepClasses.exclude );
			};

			// Add default transition function if one wasn't defined
			if ( !o.transitions[ def ] ) {
				o.transitions[ def ] = function( state ) {
					return self.stepIndex( state.step.nextAll( selector.step ) );
				};
			}

			// Select initial step
			self.select.apply( self, arr( o.initialStep ) );
		},

		_fastForward: function( toIndex, relative, callback ) {
			var i = 0,
				self = this,
				stepIndex = self._currentState.stepIndex,
				stepsTaken = [ stepIndex ];

			if ( $.isFunction( relative ) ) {
				callback = relative;
				relative = undefined;
			}

			(function next() {
				self._transition( self._state( stepIndex, stepsTaken ), function( step, branch ) {
					if ( ( stepIndex = self.stepIndex( step, branch ) ) === -1 ) {
						throw new Error( '[_fastForward]: Invalid step "' + step + '"' );

					} else if ( $.inArray( stepIndex, stepsTaken ) >= 0 ) {
						throw new Error( '[_fastForward]: Recursion detected on step "' + step + '"' );

					} else {
						stepsTaken.push( stepIndex );

						if ( stepIndex === self._lastStepIndex ||
							( relative ? ++i : stepIndex ) === toIndex ) {
							callback.call( self, stepIndex, stepsTaken );

						} else {
							next();
						}
					}
				});
			})();
		},

		_find: function( needles, haystack, wrap ) {
			var element, i, l, needle, type,
				found = [],
				$haystack = haystack instanceof jQuery ? haystack : $( haystack );

			function matchElement( i, current ) {
				if ( current === needle ) {
					element = current;

					// Break from .each loop
					return false;
				}
			}

			if ( needles !== null && $haystack.length ) {
				needles = arr( needles );

				for ( i = 0, l = needles.length; i < l; i++ ) {
					element = null;
					needle = needles[ i ];
					type = typeof needle;

					if ( type === num ) {
						element = $haystack.get( needle );

					} else if ( type === str ) {
						element = document.getElementById( needle.replace( '#', '' ) );

					} else if ( type === obj ) {
						if ( needle instanceof jQuery && needle.length ) {
							needle = needle[ 0 ];
						}

						if ( needle.nodeType ) {
							$haystack.each( matchElement );
						}
					}

					if ( element ) {
						found.push( element );
					}
				}
			}

			// Returns a jQuery object by default. If the wrap argument is
			// false, it will return an array of elements instead.
			return wrap === false ? found : $( found );
		},

		_move: function( step, branch, relative, history, callback ) {
			var self = this,
				current = self._currentState;

			if ( typeof branch === bool ) {
				callback = history;
				history = relative;
				relative = branch;
				branch = undefined;
			}

			function move(stepIndex, stepsTaken) {
				callback.call( self, stepIndex, $.isArray( history ) ?
					history : history !== false ? stepsTaken : undefined );
			}

			if (relative === true) {

				if ( step > 0 ) {
					self._fastForward( step, relative, move );

				} else {
					callback.call( self, current.stepsActivated[
						// Normalize to zero if negative
						Math.max( 0, step + ( current.stepsActivated.length - 1 ) ) ] );
				}

			// Don't attempt to move to invalid steps
			} else if ( ( step = self.stepIndex( step, branch ) ) !== -1 ) {
				if ( step > current.stepIndex ) {
					self._fastForward(step, move);
				} else {
					move.call( self, step );
				}
			}
		},

		_state: function( stepIndex, stepsTaken ) {
			if ( !this.isValidStepIndex( stepIndex ) ) {
				return null;
			}

			var o = this.options,
				state = $.extend( true, {}, this._currentState );

			// stepsTaken must be an array of at least one step
			stepsTaken = arr( stepsTaken || stepIndex );

			state.step = this.elements.steps.eq( stepIndex );
			state.branch = state.step.parent();
			state.branchStepCount = state.branch.children( selector.step ).length;
			state.isMovingForward = stepIndex > state.stepIndex;
			state.stepIndexInBranch = state.branch.children( selector.step ).index( state.step );

			var branchLabel, indexOfBranch, indexOfStep,
				i = 0,
				l = stepsTaken.length;

			for ( ; i < l; i++ ) {
				stepIndex = stepsTaken[ i ];
				branchLabel = this._branchLabels[ stepIndex ];

				// Going forward
				if ( !state.stepIndex || state.stepIndex < stepIndex ) {

					// No duplicate steps
					if ( $.inArray( stepIndex, state.stepsActivated ) < 0 ) {
						if ( state.stepsActivated === undefined )
							state.stepsActivated = [];
						state.stepsActivated.push( stepIndex );

						// No duplicate branch labels
						if ( $.inArray( branchLabel, state.branchesActivated ) < 0 ) {
							if ( state.branchesActivated === undefined )
								state.branchesActivated = [];
							state.branchesActivated.push( branchLabel );
						}
					}

				// Going backward
				} else if ( state.stepIndex > stepIndex ) {
					indexOfBranch = $.inArray( branchLabel, state.branchesActivated ) + 1;
					indexOfStep = $.inArray( stepIndex, state.stepsActivated ) + 1;

					// Don't remove initial branch
					if ( indexOfBranch > 0 ) {
						state.branchesActivated.splice( indexOfBranch,
								// IE requires this argument
								state.branchesActivated.length - 1 );
					}

					// Don't remove the initial step
					if ( indexOfStep > 0 ) {
						state.stepsActivated.splice( indexOfStep,
								// IE requires this argument
								state.stepsActivated.length - 1 );
					}
				}

				state.stepIndex = stepIndex;
				state.branchLabel = branchLabel;
			}

			// Steps completed: the number of steps we have visited
			state.stepsComplete = Math.max( 0, this._find(
				state.stepsActivated, this.elements.steps
			).filter( this._excludesFilter ).length - 1 );

			// Steps possible: the number of steps in all of the branches we have visited
			state.stepsPossible = Math.max( 0, this._find(
				state.branchesActivated, this.elements.branches
			).children( selector.step ).filter( this._excludesFilter ).length - 1 );

			$.extend( state, {
				branchLabel: this._branchLabels[ stepIndex ],
				isFirstStep: stepIndex === 0,
				isFirstStepInBranch: state.stepIndexInBranch === 0,
				isLastStep: stepIndex === this._lastStepIndex,
				isLastStepInBranch: state.stepIndexInBranch === state.branchStepCount - 1,
				percentComplete: ( 100 * state.stepsComplete / state.stepsPossible ),
				stepsRemaining: ( state.stepsPossible - state.stepsComplete )
			});

			return state;
		},

		_makeTransition: function(state, action, stateName, transitionFunc, shouldApply)
		{
			var response,
				self = this;

			if ( $.isFunction( transitionFunc ) ) {
				transitionFunc.call( self, state, function() {
					return action.apply( self, aps.call( arguments ) );
				}, shouldApply).then(function (val) {
					response = val;

					// A response of 'undefined' or 'false' will halt immediate action
					// waiting instead for the transition function to handle the call
					if (response !== undefined && response !== false) {

						// Response could be array like [ step, branch ]
						action.apply(self, arr(response));

						self.focusCurrentStep();
					}
				});

			} else {
				response = stateName;

				// A response of 'undefined' or 'false' will halt immediate action
				// waiting instead for the transition function to handle the call
				if (response !== undefined && response !== false) {

					// Response could be array like [ step, branch ]
					action.apply(self, arr(response));

					self.focusCurrentStep();
				}
			}
		},

		_transition: function( state, action ) {
			var self = this,
				o = self.options,
				currentIndex = self._currentState.stepIndex,
				currentStep = self.config.currentStep,
				stateName = state.step.attr( o.stateAttribute ),
				transitionFunc = stateName ? o.transitions[ stateName ] : o.transitions[ def ];

			if (self.config.isEditableMode && (currentStep === currentIndex + 1 || !self.config.disallowEdit) && self.config.stepConfig[currentIndex].applyOnForward)
			{
				self.savePreviousSteps(currentIndex - 1, function()
				{
					self._makeTransition(state, action, stateName, transitionFunc, true);
				});
			}
			else
				self._makeTransition(state, action, stateName, transitionFunc, false);
		},

		_update: function( event, state, force ) {
			var self = this,
				current = self._currentState,
				data = [ state, function( response ) {
					self._update( event, state, response !== false );
				} ],
				o = self.options;

			if ( current.step ) {
				if (
					!state ||
					o.disabled ||
					state.stepIndex === current.stepIndex ||
					force !== true && (
						!this._trigger( beforeSelect, event, data ) ||
						( state.isMovingForward && !this._trigger( beforeForward, event, data ) ) ||
						( !state.isMovingForward && !this._trigger( beforeBackward, event, data ) )
					)
				) {
					return;
				}

				current.step.removeClass( o.stepClasses.current )
					.animate( o.animations.hide.properties,
						// Fixes #3583 - http://bugs.jquery.com/ticket/3583
						$.extend( {}, o.animations.hide.options ) );
			}

			// Note that this does not affect the value of 'current'
			this._currentState = state;
			this.config.pathUntilState[state.stepIndex] = state.stepsActivated;
			for (let i = state.stepIndex - 1; i >= 0; i--)
			{
				if (this.config.pathUntilState[i] === undefined)
					this.config.pathUntilState[i] = [];
				else
					break;
			}

			state.step.addClass( o.stepClasses.current )
				.animate( o.animations.show.properties,
					// Fixes #3583 - http://bugs.jquery.com/ticket/3583
					$.extend( {}, o.animations.show.options ) );

			if (current.stepIndex !== undefined)
			{
				let currentPath = this.config.pathUntilState[this.config.currentStep - 1];
				let bearing = state.stepIndex - current.stepIndex;

				if (!this.config.disallowEdit || !currentPath ||
					bearing > 0 && this.config.currentStep === current.stepIndex + 1 ||
					bearing < 0 && (currentPath.length < 2 || state.stepIndex === currentPath[currentPath.length - 2]))
					this.config.currentStep = state.stepIndex + 1;

				this.updateDynamicWizard(bearing, current.stepIndex, state.stepIndex);
				this.updateWizardProgress(state.stepIndex, true);
				this.lockStepsContent(state.stepIndex);
			}

			if ( current.step ) {
				this._trigger( afterSelect, event, state );
				this._trigger( state.isMovingForward ? afterForward : afterBackward, event, state );
			}
		},

		backward: function( event, howMany ) {
			var self = this;

			if ( typeof event === num ) {
				howMany = event;
				event = undefined;
			}

			if ( howMany === undefined ) {
				howMany = 1;
			}

			if ( this._currentState.isFirstStep || typeof howMany !== num ) {
				return;
			}

			// Runs some validations before actually going back.
			this.onBackward(function()
			{
				self._move(-howMany, true, false, function(stepIndex, stepsTaken)
				{
					self._update(event, self._state(stepIndex, stepsTaken));
				});
			});
		},

		branch: function( branch ) {
			return arguments.length ?
				this._find( branch, this.elements.branches ) : this._currentState.branch;
		},

		branches: function( branch ) {
			return arguments.length ?
				this.branch( branch ).children( selector.branch ) : this.elements.branches;
		},

		branchesActivated: function() {
			return this._find( this._currentState.branchesActivated, this.elements.branches );
		},

		destroy: function( event, force ) {
			var self = this,
				$elements = self.elements,
				data = [ self.state(), function( response ) {
					return self.destroy( event, response !== false );
				} ];

			// args: force
			if ( typeof event === bool ) {
				force = event;
				event = undefined;
			}

			if ( force !== true && !self._trigger( beforeDestroy, event, data ) ) {
				return;
			}

			self.elements.backward.off( "." + namespace );
			self.elements.forward.off( "." + namespace );

			self.element.removeClass( wizard );

			$elements.form.removeClass( className.form );
			$elements.header.removeClass( className.header );
			$elements.steps.show().removeClass( className.step );
			$elements.stepsWrapper.removeClass( className.wrapper );
			$elements.branches.removeClass( className.branch );

			$.Widget.prototype.destroy.call( self );

			self._trigger( afterDestroy );
		},

		form: function() {
			return this.elements.form;
		},

		forward: function (event, howMany, history) {
			var self = this;

			if ( typeof event === num ) {
				history = howMany;
				howMany = event;
				event = undefined;
			}

			if ( howMany === undefined ) {
				howMany = 1;
			}

			if ( this._currentState.isLastStep || typeof howMany !== num ) {
				return;
			}

			this._move(howMany, true, history, function(stepIndex, stepsTaken)
			{
				self._update(event, self._state(stepIndex, stepsTaken));
			});
		},

		isValidStep: function( step, branch ) {
			return this.isValidStepIndex( this.stepIndex( step, branch ) );
		},

		isValidStepIndex: function( stepIndex ) {
			return typeof stepIndex === num && stepIndex >= 0 && stepIndex <= this._lastStepIndex;
		},

		stepCount: function() {
			return this._stepCount;
		},

		select: function( event, step, branch, relative, history ) {

			// args: step, branch, relative, history
			if ( !( event instanceof $.Event ) ) {
				history = relative;
				relative = branch;
				branch = step;
				step = event;
				event = undefined;
			}

			if ( step === undefined ) {
				return;
			}

			// args: [ step, branch ], relative, history
			if ( $.isArray( step ) ) {
				history = relative;
				relative = branch;
				branch = step[ 1 ];
				step = step[ 0 ];

			// args: step, relative, history
			} else if ( typeof branch === bool ) {
				history = relative;
				relative = branch;
				branch = undefined;

			// args: step, history
			} else if ( $.isArray( branch ) ) {
				history = branch;
				branch = undefined;
			}

			this._move( step, branch, relative, history, function( stepIndex, stepsTaken ) {
				this._update( event, this._state( stepIndex, stepsTaken ) );
			});
		},

		state: function( step, branch, stepsTaken ) {
			if ( !arguments.length ) {
				return this._currentState;
			}

			// args: [ step, branch ], stepsTaken
			if ( $.isArray( step ) ) {
				stepsTaken = branch;
				branch = step[ 1 ];
				step = step[ 0 ];

			// args: step, stepsTaken
			} else if ( $.isArray( branch ) ) {
				stepsTaken = branch;
				branch = undefined;
			}

			return this._state( this.stepIndex( step, branch ), stepsTaken );
		},

		step: function( step, branch ) {
			if ( !arguments.length ) {
				return this._currentState.step;
			}

			// args: [ step, branch ]
			if ( $.isArray( step ) ) {
				branch = step[ 1 ];
				step = step[ 0 ];
			}

			var $step,
				type = typeof step;

			// Searching for a step by index
			if ( type === num ) {
				$step = this._find( step,
					// Search within branch, if defined, otherwise search all steps
					branch !== undefined ? this.steps( branch ) : this.elements.steps );

			// Searching for a step or branch by string ID, DOM element or jQuery object
			} else {
				$step = this._find( step, this.elements.steps.add( this.elements.branches ) );

				if ( $step && $step.hasClass( className.branch ) ) {

					// If a branch is found, the arguments are essentially flip-flopped
					$step = this._find( branch || 0, this.steps( $step ) );
				}
			}

			return $step;
		},

		stepIndex: function( step, branch, relative ) {
			if ( !arguments.length ) {
				return this._currentState.stepIndex;
			}

			var $step;

			// args: [ step, branch ], relative
			if ( $.isArray( step ) ) {
				relative = branch;
				branch = step[ 1 ];
				step = step[ 0 ];

			// args: step, relative
			} else if ( typeof branch === bool ) {
				relative = branch;
				branch = undefined;
			}

			return ( $step = this.step( step, branch ) ) ?
				// The returned index can be relative to a branch, or to all steps
				( relative ? $step.siblings( selector.step ).andSelf() : this.elements.steps ).index( $step )
				: -1;
		},

		steps: function( branch ) {
			return arguments.length ?
				this.branch( branch ).children( selector.step ) : this.elements.steps;
		},

		stepsActivated: function() {
			return this._find( this._currentState.stepsActivated, this.elements.steps );
		},

		submit: function() {
			this.elements.form.submit();
		},

		//-------------------------------------------------------------------------------------
		// Custom functions
		//-------------------------------------------------------------------------------------

		handleScroller: function()
		{
			if (this.config.isVertical)
				return;

			var stepNumber = $(this.config.containerId).find('.step-buttons').children().length;
			if (stepNumber > this.config.visibleSteps)
			{
				let paths = this.config.pathUntilState;
				let steps = paths[paths.length - 1];
				if (!this.config.hasScroller)
				{
					$('.horiz-carousel-btn').css('display', 'flex');
					this.config.hasScroller = true;
				}

				let firstStep = parseInt($(this.config.containerId).find('.step-link:visible').first().attr('step'));
				let initialStep = paths[0][0] + 1;
				if (firstStep != initialStep)
					$('.carousel-control-prev').css('pointer-events', 'inherit');
				else
					$('.carousel-control-prev').css('pointer-events', 'none');

				let lastStep = parseInt($(this.config.containerId).find('.step-link:visible').last().attr('step'));
				let finalStep = this.config.isDynamic ? steps[steps.length - 1] + 1 : this.config.totalSteps;
				if (lastStep != finalStep)
					$('.carousel-control-next').css('pointer-events', 'inherit');
				else
					$('.carousel-control-next').css('pointer-events', 'none');
			}
			else if (this.config.hasScroller)
			{
				$('.horiz-carousel-btn').hide();
				this.config.hasScroller = false;
			}
		},

		addStep: function(step)
		{
			var container = $(this.config.containerId);
			var currentStep = parseInt(container.find('.step-link').length);
			if (isNaN(currentStep))
				currentStep = 0;
			var stepConfig = this.config.stepConfig[step - 1];
			var isRequired = this.config.stepConfig[step - 1].isRequired;

			var stepId = 'step-button-' + this.config.wizardName + '-' + step;
			var stepArea = 'wizard-step-' + this.config.wizardName + '-' + step;
			var requiredIcon = '<i class="required-icon glyphicons glyphicons-asterisk e-icon"></i>';
			var filledIcon = '<i class="filled-icon glyphicons glyphicons-ok-sign e-icon hidden"></i>';
			var numberBody = '<span class="q-wizard__step-number">' + (currentStep + 1) + '</span>';
			var btnClass = this.config.stepsAreBlocked ? 'disabled' : 'filled-step';
			var iconBody = '<span class="q-wizard__step-icon">'
				+ '<i class="' + stepConfig.icon + ' e-icon"></i>'
				+ '</span>';

			var stepBody = '<li id="' + stepId + '" class="step-link q-wizard__step ' + btnClass + '" step="' + step + '" step-area="' + stepArea + '">'
				+ '<a href="javascript:void(0)">'
				+ (stepConfig.icon.length > 0 ? iconBody : numberBody)
				+ '</a>'
				+ (this.config.showTitles ? '<a href="javascript:void(0)" class="btn q-wizard__step-link">'
				+ stepConfig.title + ' ' + (isRequired ? requiredIcon : '') + filledIcon
				+ '</a>'
				+ (stepConfig.caption.length > 0 ? '<label class="wizard-step-caption">' + stepConfig.caption + '</label>' : '')
				+ '</li>' : '');

			container.find('.step-buttons').append(stepBody);

			if (!this.config.isVertical)
			{
				// If the number of visible steps is reached, a "scroll" is created.
				if (currentStep >= this.config.visibleSteps)
				{
					$('#' + stepId).hide();
					$('#' + stepId).addClass('hidden');
					if (!this.isInitializing)
					{
						this.handleScroller();
						this.focusCurrentStep();
					}
				}
			}
		},

		setStepFilled: function(step, isFilled)
		{
			if (this.config.hasProgress)
				return;
			if (typeof isFilled === 'undefined')
				isFilled = true;

			var stepButton = $(this.config.containerId).find('#step-button-' + this.config.wizardName + '-' + step);
			var currentPath = this.config.pathUntilState[this.config.currentStep - 1];

			if (isFilled)
			{
				if (this.config.isEditableMode && (!currentPath || currentPath.length === step + 1 || !this.config.disallowEdit || this.isInitializing))
				{
					stepButton.find('.filled-icon').addClass('hidden');
					stepButton.find('.required-icon').removeClass('hidden');
				}
				stepButton.removeClass('filled-step');
				stepButton.addClass('disabled');
			}
			else
			{
				if (this.config.isEditableMode && (!currentPath || currentPath.length === step + 1 || !this.config.disallowEdit || this.isInitializing))
				{
					stepButton.find('.required-icon').addClass('hidden');
					stepButton.find('.filled-icon').removeClass('hidden');
				}
				stepButton.removeClass('disabled');
				stepButton.addClass('filled-step');
			}
		},

		disableNextSteps: function(startStep)
		{
			if (this.config.hasProgress || !this.config.stepsAreBlocked)
				return;

			var step = startStep;
			do
			{
				if (isNaN(step))
					break;

				this.setStepFilled(step);

				let stepButton = $(this.config.containerId).find('#step-button-' + this.config.wizardName + '-' + step);
				let nextStep = stepButton.next();
				if (nextStep.length <= 0)
					break;

				step = parseInt(nextStep.attr('step'));
			}
			while (step <= this.config.totalSteps);
		},

		disableStep: function(step)
		{
			if (!this.config.isDynamic && !this.config.stepsAreBlocked || !this.config.isEditableMode || this.config.currentStep !== step && this.config.disallowEdit)
				return;

			var paths = this.config.pathUntilState;
			do
				paths.pop();
			while (paths[paths.length - 1].length == 0);

			this.disableNextSteps(step);
		},

		removeStep: function(step)
		{
			var stepButton = $(this.config.containerId).find('#step-button-' + this.config.wizardName + '-' + step);
			this.scrollLeft();
			stepButton.remove();
			this.handleScroller();
		},

		removeAllNextSteps: function(startingStep)
		{
			var lastStep = parseInt($(this.config.containerId).find('.step-link').last().attr('step'));
			if (!isNaN(lastStep))
			{
				let current = startingStep + 1;
				while (current <= lastStep)
				{
					this.removeStep(current);
					current++;
				}
			}
		},

		updateDynamicWizard: function(direction, currentStep, nextStep)
		{
			if (this.config.totalSteps == 0 || !this.config.isDynamic)
				return;

			if (!this.isInitializing && (!this.config.isEditableMode || this.config.currentStep !== nextStep + 1 && this.config.disallowEdit))
				return;

			if (direction < 0)
				this.removeAllNextSteps(currentStep);
			else
			{
				if (!this.isInitializing)
					this.removeAllNextSteps(nextStep - direction + 1);
				this.addStep(nextStep + 1);
			}
		},

		updateWizardButtons: function(step)
		{
			var wizard = $(this.config.wizardId);
			var stepList = this.config.pathUntilState[this.config.pathUntilState.length - 1];
			var steps = this._currentState.stepsActivated;
			var currentStep;
			if (this.config.isEditableMode)
				currentStep = this.config.currentStep;
			else
				currentStep = stepList[stepList.length - 1] + 1;

			if (!this.config.stepConfig[step - 1].applyIsOff)
			{
				let applyButton = wizard.find('.apply-option').find('button');
				if (applyButton.length > 0)
				{
					applyButton.prop('disabled', false);
					applyButton.removeClass('q-wizard-btn-disabled');
				}
			}
			else
			{
				let applyButton = wizard.find('.apply-option').find('button');
				if (applyButton.length > 0)
				{
					applyButton.prop('disabled', true);
					applyButton.addClass('q-wizard-btn-disabled');
				}
			}

			if (!this.config.stepConfig[step - 1].backwardIsOff && (steps === undefined || steps[0] !== undefined && step !== steps[0] + 1))
			{
				let backButton = wizard.find('.backward-option').find('button');
				if (backButton.length > 0)
				{
					backButton.prop('disabled', false);
					backButton.removeClass('q-wizard-btn-disabled');
				}
			}
			else
			{
				let backButton = wizard.find('.backward-option').find('button');
				if (backButton.length > 0)
				{
					backButton.prop('disabled', true);
					backButton.addClass('q-wizard-btn-disabled');
				}
			}

			if ((!this.config.stepConfig[step - 1].forwardIsOff && step < this.config.totalSteps && this.config.isEditableMode) ||
				// When the form isn't editable, we don't want the "forward" button to be clickable when the next steps at the top are not!
				(step < currentStep && !this.config.isEditableMode))
			{
				let fwdButton = wizard.find('.forward-option').find('button');
				if (fwdButton.length > 0)
				{
					fwdButton.prop('disabled', false);
					fwdButton.removeClass('q-wizard-btn-disabled');
				}
			}
			else
			{
				let fwdButton = wizard.find('.forward-option').find('button');
				if (fwdButton.length > 0)
				{
					fwdButton.prop('disabled', true);
					fwdButton.addClass('q-wizard-btn-disabled');
				}
			}
		},

		lockStepsContent: function(step)
		{
			var self = this;
			if (!self.config.disallowEdit || !self.config.isEditableMode || self.config.currentStep !== step + 1 && self.config.disallowEdit)
				return;

			$(document).ready(function()
			{
				for (let i = 0; i < self.config.totalSteps; i++)
				{
					let stepForm = window[self.config.stepConfig[i].formName];
					if (stepForm === undefined)
						continue;

					// If it's the current step, we enable the fields, otherwise we block them.
					let isBlocked = step != i;
					let controls = stepForm.Controls;
					for (let c in controls)
					{
						if (typeof controls[c].controlId != 'string' || controls[c].controlId.length == 0)
							continue;

						let control = $('#' + controls[c].controlId);
						let isReadOnly = control.attr('readonly') == 'readonly';
						let wasChanged = control.attr('q-wizard-changed') == 'true';

						if (!isReadOnly || wasChanged)
						{
							let stepId = '#' + self.config.stepConfig[i].stepId;
							let pointerEvents = isBlocked ? 'none' : 'inherit';
							$(stepId).find('input, button').prop('disabled', isBlocked);
							$(stepId).find('a').not('[elem-identifier="AccordionToggle"], [data-toggle="tab"]').css('pointer-events', pointerEvents);
							$(stepId).find('tr').css('pointer-events', pointerEvents);
							controls[c].Block('JustVisualization', isBlocked);
							control.attr('q-wizard-changed', true);
						}
					}
				}
			});
		},

		changeStep: function(step, setFilledInfo)
		{
			if (step < 1 || step > this.config.totalSteps)
				return;

			var stepList = this.config.pathUntilState[this.config.pathUntilState.length - 1];
			var container = $(this.config.containerId);
			var wizard = $(this.config.wizardId);
			wizard.find('.step').hide();
			var wizardStep = wizard.find('#wizard-step-' + this.config.wizardName + '-' + step);
			wizardStep.show();
			container.find('.current-step').removeClass('current-step');

			var stepButton = container.find('#step-button-' + this.config.wizardName + '-' + step);
			stepButton.removeClass('disabled');
			stepButton.addClass('filled-step current-step');

			var previousButton = stepButton.prev();
			while (previousButton.length > 0)
			{
				let previousStep = parseInt(previousButton.attr('step'));
				if (setFilledInfo)
					this.setStepFilled(previousStep, false);
				previousButton = previousButton.prev();
			}

			this.updateWizardButtons(step);
			this.lockStepsContent(stepList[stepList.length - 1]);
		},

		updateProgressBar: function(step)
		{
			if (step < 1 || step > this.config.totalSteps)
				return;
			var progress = step / this.config.totalSteps * 100;
			$(this.config.containerId).find('.wizard-progress').find('.progress-bar').css({ 'width': progress + '%' });
			this.updateWizardButtons(step);
		},

		updateWizardProgress: function(step, setFilledInfo)
		{
			if (typeof setFilledInfo === 'undefined')
				setFilledInfo = false;

			step = parseInt(step);
			var stepHeader = '';
			var container = $(this.config.containerId);
			var icon = this.config.stepConfig[step].icon;
			var isRequired = this.config.stepConfig[step].isRequired;

			this.config.selectedStep = step + 1;
			if (this.config.hasSteps)
				this.changeStep(step + 1, setFilledInfo);
			else if (this.config.hasProgress)
				this.updateProgressBar(step + 1);

			var currentStep = this.config.isDynamic ? this._currentState.stepsActivated.length : this.config.selectedStep;
			if (icon.length > 0)
			{
				stepHeader += '<span class="q-wizard__step-icon">'
					+ '<i class="' + icon + ' e-icon"></i>'
					+ '</span>';
			}
			else
				stepHeader += '<span class="q-wizard__step-number">' + currentStep + '</span>';

			stepHeader += '<h3>'
				+ this.config.stepConfig[step].title
				+ (isRequired ? ' <span class="required-step-header">*</span>' : '')
				+ '</h3>';
			container.find('.step-title').html(stepHeader);
		},

		loadStep: function(step, update)
		{
			if (!update || isNaN(step) || step < 1 || step > this.config.totalSteps)
				return;
			var state = this.state(step - 1);
			if (state === null)
				return;

			this._currentState = state;
			this._currentState.stepsActivated = this.config.pathUntilState[step - 1];
			this.updateWizardProgress(step - 1);
		},

		recursiveSaveSteps: function(stepList, callback)
		{
			var self = this;

			if (stepList.length == 0)
			{
				if (typeof callback === 'function')
					callback();
				return;
			}

			var stepData = stepList.pop();
			saveWizardState(stepData.area, stepData.id, function(message, success)
			{
				if (success)
					self.recursiveSaveSteps(stepList, callback);
				else
					displayMessage(message);
			});
		},

		savePreviousSteps: function(step, callback)
		{
			var stepList = [];
			for (let i = step; i >= 0; i--)
			{
				if (this.config.stepConfig[i].applyOnForward)
					break;
				if (this.config.pathUntilState[i].length == 0)
					continue;

				let wizardArea = $(this.config.wizardId);
				let stepId = $(this.config.containerId).find('.step[step="' + (i + 1) + '"]').first().attr('id');
				stepList.push({ index: i, id: stepId, area: wizardArea });
			}

			stepList.sort(function(a, b) { return b.index - a.index });
			this.recursiveSaveSteps(stepList, callback);
		},

		selectStep: function(step, areaId, update, forceReload)
		{
			var self = this;
			if (isNaN(step) || step < 1 || step > self.config.totalSteps)
				return;

			var stepArea = $('#' + areaId);
			var state = self.state(step - 1);
			var stepLoaded = stepArea.attr('step-loaded') == 'true';
			self._trigger(beforeSelect, event, state);
			if (stepLoaded && !forceReload)
			{
				self.loadStep(step, update);
				self._trigger(afterSelect, event, state);
			}
			else
			{
				if (stepLoaded)
					stepArea.attr('step-loaded', false);

				loadWizardStep(stepArea, function(error)
				{
					if (error === undefined)
					{
						self.loadStep(step, update);
						self._trigger(afterSelect, event, state);
					}
				});
			}
		},

		selectPreviousStep: function(currentStep, nextStep, callbackFunc)
		{
			var currentPath = this.config.pathUntilState[currentStep - 1];
			if (currentPath.length < 2)
				return;

			var nextStepIndex = currentPath[currentPath.length - 2];
			var currentStepArea = $(this.config.containerId).find('.step[step="' + currentStep + '"]').first();
			var nextStepArea = $(this.config.containerId).find('.step[step="' + nextStep + '"]').first();
			var nextStepId = nextStepArea.attr('id');
			var formName = this.config.stepConfig[currentStep - 1].formName;
			var reloadNextStep = this.config.stepConfig[nextStepIndex].reloadStep;

			this.setStepFilled(nextStep);
			this.selectStep(nextStep, nextStepId, false, reloadNextStep);
			this.disableStep(currentStep);
			this.config.selectedStep = nextStepIndex + 1;

			$.localStorageFormRemove($(window[formName].element));
			delete window[formName];
			currentStepArea.attr('step-loaded', false);
			currentStepArea.empty();
			callbackFunc();
			this.focusCurrentStep();
		},

		goBack: function(currentStep, nextStep, callbackFunc)
		{
			var self = this;

			var wizardArea = $(self.config.wizardId);
			var currentStepArea = $(self.config.containerId).find('.step[step="' + currentStep + '"]').first();
			var currentStepId = currentStepArea.attr('id');
			var stepConfig = self.config.stepConfig[currentStep - 1];

			if (self.config.isEditableMode && (self.config.currentStep === currentStep || !self.config.disallowEdit) && (stepConfig.applyOnBackward || stepConfig.clearOnBackward))
			{
				let state = self._currentState;
				self._trigger(beforeSave, event, state);
				saveWizardState(wizardArea, currentStepId, function(message, success)
				{
					var json = { message, success };
					self._trigger(afterSave, event, [state, json]);
					self.selectPreviousStep(currentStep, nextStep, callbackFunc);
				}, true, stepConfig.clearOnBackward);
			}
			else
				self.selectPreviousStep(currentStep, nextStep, callbackFunc);
		},

		onBackward: function(callbackFunc)
		{
			var self = this;
			var steps = self._currentState.stepsActivated;
			if (steps.length < 2)
				return;

			var currentStep = steps[steps.length - 1] + 1;
			var nextStep = steps[steps.length - 2] + 1;
			var stepConfig = self.config.stepConfig[currentStep - 1];
			var formName = stepConfig.formName;

			// If some fields are dirty, confirms that the user really wants to go to the previous step.
			if (self.config.isEditableMode && (self.config.currentStep === currentStep || !self.config.disallowEdit) &&
				typeof window[formName] !== 'undefined' &&
				window[formName].isDirty &&
				!stepConfig.applyOnBackward)
			{
				let buttons = [
					{
						label: quidgestGlobals.Resources.YES,
						style: MessageDefs.ButtonTypes.Primary,
						callback: function()
						{
							self.goBack(currentStep, nextStep, callbackFunc);
						}
					},
					{
						label: quidgestGlobals.Resources.NO,
						style: MessageDefs.ButtonTypes.Secondary
					}
				];
				displayMessage(quidgestGlobals.Resources.CONFIRM_EXIT_FORM_DIRTY, undefined, undefined, buttons);
			}
			else
				self.goBack(currentStep, nextStep, callbackFunc);
		},

		initWizard: function()
		{
			var self = this;
			var wizard = $(this.config.wizardId);

			// Loads the content of the first/current step of this wizard.
			getWizardState(wizard, function(path)
			{
				var key = self.getStorageKey();
				var stepList = {};
				if (typeof localStorage.current_wizard_steps === 'string')
					stepList = JSON.parse(localStorage.current_wizard_steps);

				var isStored = typeof stepList[key] === 'string' && path.includes(stepList[key]);
				var storedStep = isStored ? stepList[key] : null;
				delete stepList[key];

				var latestStepId = path[path.length - 1];
				var stepId = isStored ? storedStep : self.config.isEditableMode ? latestStepId : path[0];
				var currentStep = $('#' + stepId);
				var currentIndex = parseInt(stepId.split('-').pop()) - 1;
				var activeSteps = [];
				self._currentState.stepsActivated = [];
				self.config.pathUntilState[0] = [];
				self.config.currentStep = parseInt(latestStepId.split('-').pop());
				self.config.selectedStep = currentIndex + 1;

				for (let i = 0; i < path.length; i++)
				{
					let stepIndex = parseInt(path[i].split('-').pop()) - 1;
					if (!activeSteps.includes(stepIndex))
					{
						activeSteps.push(stepIndex);
						self.config.pathUntilState[stepIndex] = [...activeSteps];
						for (let j = stepIndex - 1; j >= 0; j--)
						{
							if (self.config.pathUntilState[j] === undefined)
								self.config.pathUntilState[j] = [];
							else
								break;
						}
					}

					self._currentState.stepsActivated = self.config.pathUntilState[stepIndex];
					self.updateDynamicWizard(stepIndex + 1, stepIndex, stepIndex);
					self.updateWizardProgress(stepIndex, true);
				}
				self._currentState = self.state(currentIndex);
				self._currentState.stepsActivated = self.config.pathUntilState[currentIndex];

				// If the steps are clickable, we need to populate the paths so there won't be an error when clicking on their backward button.
				if (!self.config.isDynamic && !self.config.stepsAreBlocked)
					for (let i = 0; i < self.config.totalSteps; i++)
						if (self.config.pathUntilState[i] === undefined || self.config.pathUntilState[i].length === 0)
						{
							let list = [];
							for (let j = 0; j <= i; j++)
								list.push(j);
							self.config.pathUntilState[i] = list;
						}

				// Sets the visibility of the save button.
				toggleSaveButton(wizard.attr('id'), currentIndex + 1);

				// Loads the content of the current step before the others.
				loadWizardStep(currentStep, function(error)
				{
					// If there are no errors, the wizard should now be loaded and ready.
					if (error === undefined)
					{
						$(self.config.containerId).show();
						self.selectStep(currentIndex + 1, stepId, true, false);
						self.handleScroller();
						self.focusCurrentStep();
					}
				});

				// Also loads the content of the steps already completed.
				for (let i = 0; i < path.length; i++)
					if (i != currentIndex)
						loadWizardStep($('#' + path[i]));

				self.isInitializing = false;
			});
		},

		focusCurrentStep: function()
		{
			if (!this.config.hasScroller)
				return;

			var currentStep = $(this.config.containerId).find('.current-step').first();
			var currentStepId = currentStep.attr('step');

			while (!currentStep.is(':visible'))
			{
				let firstStep = parseInt($(this.config.containerId).find('.step-link:visible').first().attr('step'));
				let lastStep = parseInt($(this.config.containerId).find('.step-link:visible').last().attr('step'));
				if (isNaN(firstStep) || isNaN(lastStep))
					break;

				if (currentStepId < firstStep)
					this.scrollLeft();
				else if (currentStepId > lastStep)
					this.scrollRight();
			}
		},

		scrollLeft: function()
		{
			if (!this.config.hasScroller)
				return;

			var firstStep = $(this.config.containerId).find('.step-link:visible').first();
			var lastStep = $(this.config.containerId).find('.step-link:visible').last();
			var previousStep = firstStep.prev();

			if (previousStep.length <= 0)
				return;

			lastStep.hide();
			lastStep.addClass('hidden');
			previousStep.css('display', 'flex');
			previousStep.removeClass('hidden');
			this.handleScroller();
		},

		scrollRight: function()
		{
			if (!this.config.hasScroller)
				return;

			var firstStep = $(this.config.containerId).find('.step-link:visible').first();
			var lastStep = $(this.config.containerId).find('.step-link:visible').last();
			var nextStep = lastStep.next();

			if (nextStep.length <= 0)
				return;

			firstStep.hide();
			firstStep.addClass('hidden');
			nextStep.css('display', 'flex');
			nextStep.removeClass('hidden');
			this.handleScroller();
		},

		getStorageKey: function()
		{
			var formName = this.config.formName;
			var wizard = this.config.wizardName;
			var recordId = $(this.config.wizardId).attr('q-record-id');
			var recordKey = $('#' + recordId).val();
			return formName + '-' + wizard + '-' + recordKey;
		},

		initConfig: function()
		{
			var self = this;

			this.isInitializing = true;
			this.config = {};
			this.config.stepConfig = [];
			this.config.visibleSteps = 5; // Only used if the wizard has steps and they are horizontally aligned.
			this._trigger(onCreate, null, [this.config]);
			if (isNaN(this.config.visibleSteps))
				this.config.visibleSteps = 5;
			else if (this.config.visibleSteps < 1)
				this.config.visibleSteps = 1;
			else if (this.config.visibleSteps > 10)
				this.config.visibleSteps = 10;
			this.config.totalSteps = this.config.stepConfig.length;

			if (typeof this.config.wizardName != 'string')
				throw new Error('The name of the target wizard wasn\'t specified.');
			if (typeof this.config.wizardId != 'string')
				throw new Error('The id of the target wizard wasn\'t specified.');
			if (typeof this.config.isDynamic != 'boolean')
				throw new Error('The wizard "isDynamic" flag wasn\'t correctly set.');
			if (typeof this.config.isVertical != 'boolean')
				throw new Error('The wizard "isVertical" flag wasn\'t correctly set.');
			if (typeof this.config.hasSteps != 'boolean')
				throw new Error('The wizard "hasSteps" flag wasn\'t correctly set.');
			if (typeof this.config.hasProgress != 'boolean')
				throw new Error('The wizard "hasProgress" flag wasn\'t correctly set.');
			if (this.config.totalSteps == 0)
				throw new Error('The wizard has no steps.');

			this.config.containerId = '#q-wizard-container-' + this.config.wizardName;
			this.config.pathUntilState = [];
			this.config.hasScroller = false;

			if (this.config.hasSteps && !this.config.isDynamic)
				for (let i = 0; i < this.config.totalSteps; i++)
					this.addStep(i + 1);

			window.addEventListener('beforeunload', function()
			{
				var key = self.getStorageKey();
				var current = self.config.selectedStep - 1;
				var stepList = {};

				if (typeof localStorage.current_wizard_steps === 'string')
					stepList = JSON.parse(localStorage.current_wizard_steps);

				stepList[key] = self.config.stepConfig[current].stepId;
				localStorage.setItem('current_wizard_steps', JSON.stringify(stepList));
			});

			$(this.config.containerId).find('.wizard-steps').on('click', '.step-link', function()
			{
				var step = parseInt($(this).attr('step'));
				var areaId = $(this).attr('step-area');
				var reloadStep = self.config.stepConfig[step - 1].reloadStep;
				self.selectStep(step, areaId, true, reloadStep);
			});

			$(this.config.containerId).find('.carousel-control-prev').click(function()
			{
				self.scrollLeft();
			});

			$(this.config.containerId).find('.carousel-control-next').click(function()
			{
				self.scrollRight();
			});

			$(this.config.wizardId).find('button.save').click(function()
			{
				var currentStep = self.config.selectedStep;
				if (!self.config.isEditableMode || self.config.currentStep !== currentStep && self.config.disallowEdit)
					return;

				var wizardArea = $(self.config.wizardId);
				var stepElement = wizardArea.find('.wizard-step[step=' + currentStep + ']').first();
				var stepId = stepElement.attr('id');
				var formName = self.config.stepConfig[currentStep - 1].formName;
				var state = self._currentState;

				self._trigger(beforeSave, event, state);
				self.savePreviousSteps(currentStep - 2, function()
				{
					saveWizardState(wizardArea, stepId, function(message, success, view)
					{
						var json = { message, success };
						self._trigger(afterSave, event, [state, json]);
						if (!success && view !== undefined && view.length > 0)
						{
							let form = window[formName];
							delete window[formName];
							form.ReplaceHTML(view);
						}
						else
						{
							wizardArea.find('.validation-summary-errors').remove();
							displayMessage(message);
						}
					});
				});
			});

			this.initWizard();
		}
	});

})( jQuery );