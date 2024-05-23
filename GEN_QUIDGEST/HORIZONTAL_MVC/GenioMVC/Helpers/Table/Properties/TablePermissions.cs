using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSGenio.framework;

namespace GenioMVC.Helpers.Table.Properties
{
    public class TablePermissions
    {
        private bool m_CanView;
        public bool CanView {
            get {
                return m_CanView;
            }
            private set {
                m_CanView = value;
            }
        }
        private bool m_CanInsert;
        public bool CanInsert
        {
            get
            {
                return IsInEditMode && m_CanInsert && !Maintenance.Current.IsActive;
            }
            private set
            {
                m_CanInsert = value;
            }
        }
        private bool m_CanEdit;
        public bool CanEdit
        {
            get
            {
                return IsInEditMode && m_CanEdit && !Maintenance.Current.IsActive;
            }
            private set
            {
                m_CanEdit = value;
            }
        }
        private bool m_CanDuplicate;
        public bool CanDuplicate
        {
            get
            {
                return IsInEditMode && m_CanDuplicate && !Maintenance.Current.IsActive;
            }
            private set
            {
                m_CanDuplicate = value;
            }
        }
        private bool m_CanDelete;
        public bool CanDelete
        {
            get
            {
                return IsInEditMode && m_CanDelete && !Maintenance.Current.IsActive;
            }
            private set
            {
                m_CanDelete = value;
            }
        }

        private bool m_IsInEditMode;
        public bool IsInEditMode
        {
            get
            {
                return m_IsInEditMode && !Maintenance.Current.IsActive;
            }
            private set
            {
                m_IsInEditMode = value;
            }
        }

        public TablePermissions(bool isInEditMode)
        {
            CanView = CanInsert = CanEdit = CanDuplicate = CanDelete = true;
            IsInEditMode = isInEditMode;
        }

        public TablePermissions(bool view, bool insert, bool edit, bool duplicate, bool delete, bool isInEditMode)
        {
            CanView = view;
            CanInsert = insert;
            CanEdit = edit;
            CanDuplicate = duplicate;
            CanDelete = delete;
            IsInEditMode = isInEditMode;
        }

        public int NumberOfPermissons
        {
            get
            {
                int num = 0;
                num += Convert.ToInt32(CanView);
                num += Convert.ToInt32(CanInsert);
                num += Convert.ToInt32(CanEdit);
                num += Convert.ToInt32(CanDuplicate);
                num += Convert.ToInt32(CanDelete);
                return num;
            }

        }
    }
}