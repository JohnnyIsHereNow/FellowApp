﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PocaWebsite.UserServiceController {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InsertUser", Namespace="http://schemas.datacontract.org/2004/07/UserServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class InsertUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime bdayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imgURLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usrField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime bday {
            get {
                return this.bdayField;
            }
            set {
                if ((this.bdayField.Equals(value) != true)) {
                    this.bdayField = value;
                    this.RaisePropertyChanged("bday");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fn {
            get {
                return this.fnField;
            }
            set {
                if ((object.ReferenceEquals(this.fnField, value) != true)) {
                    this.fnField = value;
                    this.RaisePropertyChanged("fn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string imgURL {
            get {
                return this.imgURLField;
            }
            set {
                if ((object.ReferenceEquals(this.imgURLField, value) != true)) {
                    this.imgURLField = value;
                    this.RaisePropertyChanged("imgURL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ln {
            get {
                return this.lnField;
            }
            set {
                if ((object.ReferenceEquals(this.lnField, value) != true)) {
                    this.lnField = value;
                    this.RaisePropertyChanged("ln");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string pass {
            get {
                return this.passField;
            }
            set {
                if ((object.ReferenceEquals(this.passField, value) != true)) {
                    this.passField = value;
                    this.RaisePropertyChanged("pass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usr {
            get {
                return this.usrField;
            }
            set {
                if ((object.ReferenceEquals(this.usrField, value) != true)) {
                    this.usrField = value;
                    this.RaisePropertyChanged("usr");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/ClassLibraryPOCA")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime birthdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string first_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imageURLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string last_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime birthdate {
            get {
                return this.birthdateField;
            }
            set {
                if ((this.birthdateField.Equals(value) != true)) {
                    this.birthdateField = value;
                    this.RaisePropertyChanged("birthdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string first_name {
            get {
                return this.first_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.first_nameField, value) != true)) {
                    this.first_nameField = value;
                    this.RaisePropertyChanged("first_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string imageURL {
            get {
                return this.imageURLField;
            }
            set {
                if ((object.ReferenceEquals(this.imageURLField, value) != true)) {
                    this.imageURLField = value;
                    this.RaisePropertyChanged("imageURL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string last_name {
            get {
                return this.last_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.last_nameField, value) != true)) {
                    this.last_nameField = value;
                    this.RaisePropertyChanged("last_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateUser", Namespace="http://schemas.datacontract.org/2004/07/UserServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class UpdateUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime bdayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imgURLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usrField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime bday {
            get {
                return this.bdayField;
            }
            set {
                if ((this.bdayField.Equals(value) != true)) {
                    this.bdayField = value;
                    this.RaisePropertyChanged("bday");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fn {
            get {
                return this.fnField;
            }
            set {
                if ((object.ReferenceEquals(this.fnField, value) != true)) {
                    this.fnField = value;
                    this.RaisePropertyChanged("fn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string imgURL {
            get {
                return this.imgURLField;
            }
            set {
                if ((object.ReferenceEquals(this.imgURLField, value) != true)) {
                    this.imgURLField = value;
                    this.RaisePropertyChanged("imgURL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ln {
            get {
                return this.lnField;
            }
            set {
                if ((object.ReferenceEquals(this.lnField, value) != true)) {
                    this.lnField = value;
                    this.RaisePropertyChanged("ln");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string pass {
            get {
                return this.passField;
            }
            set {
                if ((object.ReferenceEquals(this.passField, value) != true)) {
                    this.passField = value;
                    this.RaisePropertyChanged("pass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usr {
            get {
                return this.usrField;
            }
            set {
                if ((object.ReferenceEquals(this.usrField, value) != true)) {
                    this.usrField = value;
                    this.RaisePropertyChanged("usr");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceController.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/RecordUser", ReplyAction="http://tempuri.org/IUserService/RecordUserResponse")]
        PocaWebsite.UserServiceController.User RecordUser(PocaWebsite.UserServiceController.InsertUser insertUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/RecordUser", ReplyAction="http://tempuri.org/IUserService/RecordUserResponse")]
        System.Threading.Tasks.Task<PocaWebsite.UserServiceController.User> RecordUserAsync(PocaWebsite.UserServiceController.InsertUser insertUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        PocaWebsite.UserServiceController.User GetUser(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        System.Threading.Tasks.Task<PocaWebsite.UserServiceController.User> GetUserAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        void UpdateUser([System.ServiceModel.MessageParameterAttribute(Name="updateUser")] PocaWebsite.UserServiceController.UpdateUser updateUser1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        System.Threading.Tasks.Task UpdateUserAsync(PocaWebsite.UserServiceController.UpdateUser updateUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        void DeleteUser(string usname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        System.Threading.Tasks.Task DeleteUserAsync(string usname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllUsers", ReplyAction="http://tempuri.org/IUserService/GetAllUsersResponse")]
        PocaWebsite.UserServiceController.User[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllUsers", ReplyAction="http://tempuri.org/IUserService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<PocaWebsite.UserServiceController.User[]> GetAllUsersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : PocaWebsite.UserServiceController.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<PocaWebsite.UserServiceController.IUserService>, PocaWebsite.UserServiceController.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PocaWebsite.UserServiceController.User RecordUser(PocaWebsite.UserServiceController.InsertUser insertUser) {
            return base.Channel.RecordUser(insertUser);
        }
        
        public System.Threading.Tasks.Task<PocaWebsite.UserServiceController.User> RecordUserAsync(PocaWebsite.UserServiceController.InsertUser insertUser) {
            return base.Channel.RecordUserAsync(insertUser);
        }
        
        public PocaWebsite.UserServiceController.User GetUser(string username) {
            return base.Channel.GetUser(username);
        }
        
        public System.Threading.Tasks.Task<PocaWebsite.UserServiceController.User> GetUserAsync(string username) {
            return base.Channel.GetUserAsync(username);
        }
        
        public void UpdateUser(PocaWebsite.UserServiceController.UpdateUser updateUser1) {
            base.Channel.UpdateUser(updateUser1);
        }
        
        public System.Threading.Tasks.Task UpdateUserAsync(PocaWebsite.UserServiceController.UpdateUser updateUser) {
            return base.Channel.UpdateUserAsync(updateUser);
        }
        
        public void DeleteUser(string usname) {
            base.Channel.DeleteUser(usname);
        }
        
        public System.Threading.Tasks.Task DeleteUserAsync(string usname) {
            return base.Channel.DeleteUserAsync(usname);
        }
        
        public PocaWebsite.UserServiceController.User[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<PocaWebsite.UserServiceController.User[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
    }
}