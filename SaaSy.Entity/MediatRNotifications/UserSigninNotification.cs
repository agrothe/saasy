using MediatR;
using SaaSy.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.MediatRNotifications
{
    public class UserSigninNotification<TUser> : INotification where TUser : class
    {
        public TUser User { get; set; }

    }
}
