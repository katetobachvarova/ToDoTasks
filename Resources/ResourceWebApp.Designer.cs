﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceWebApp {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceWebApp() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.ResourceWebApp", typeof(ResourceWebApp).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM Task WHERE id = :0.
        /// </summary>
        public static string DeleteToDoTaskDataSqlCmdStr {
            get {
                return ResourceManager.GetString("DeleteToDoTaskDataSqlCmdStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM Task where tododate = TO_DATE( :0, &apos;dd/mm/yyyy&apos;) AND DESCRIPTION LIKE (&apos;%&apos; || :1 || &apos;%&apos;).
        /// </summary>
        public static string FindToDoTaskByDateAndDescriptionSqlCmdStr {
            get {
                return ResourceManager.GetString("FindToDoTaskByDateAndDescriptionSqlCmdStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM Task where tododate = TO_DATE( :0, &apos;dd/mm/yyyy&apos;).
        /// </summary>
        public static string FindToDoTaskByDateSqlCmdStr {
            get {
                return ResourceManager.GetString("FindToDoTaskByDateSqlCmdStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM Task where DESCRIPTION LIKE (&apos;%&apos; || :0 || &apos;%&apos;).
        /// </summary>
        public static string FindToDoTaskByDescriptionSqlCmdStr {
            get {
                return ResourceManager.GetString("FindToDoTaskByDescriptionSqlCmdStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM Task where id=:0.
        /// </summary>
        public static string FindToDoTaskByIdSqlCmdStr {
            get {
                return ResourceManager.GetString("FindToDoTaskByIdSqlCmdStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO Task (NAME, DESCRIPTION, TODODATE, STATUS, CATEGORYID) VALUES (:0, :1, :2, :3, :4).
        /// </summary>
        public static string InsertToDoTaskDataSqlCmdStr {
            get {
                return ResourceManager.GetString("InsertToDoTaskDataSqlCmdStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE Task set name = :0, description = :1, TODODATE = :2, status = :3, categoryid = :4 where id = :5.
        /// </summary>
        public static string ModifyToDoTaskDataSqlCmdStr {
            get {
                return ResourceManager.GetString("ModifyToDoTaskDataSqlCmdStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM Task.
        /// </summary>
        public static string ReadToDoTasksDataSqlCmdStr {
            get {
                return ResourceManager.GetString("ReadToDoTasksDataSqlCmdStr", resourceCulture);
            }
        }
    }
}
