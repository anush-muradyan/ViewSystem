using System;
using System.Linq;
using DefaultNamespace;
using DefaultNamespace.Models.Autorization;
using Models.Entities;
using ScriptableObject;
using Store;
using Tools;
using UnityEngine;

namespace Services
{
    public interface IAuthorizationService
    {
        User Login(SignInModel model);
        User Register(SignUpModel model);
        User SilentLogin();
    }

    public class AuthorizationService : IAuthorizationService
    {
        private readonly IDataStore _dataStore;
        private readonly Session _session;
        private readonly IInitialData _initialData;

        public AuthorizationService(IDataStore dataStore, Session session, IInitialData initialData)
        {
            _dataStore = dataStore;
            _session = session;
            _initialData = initialData;
        }

        private User login(Func<User, bool> callback)
        {
            var user = _dataStore
                .ReadMany<User>()
                .SingleOrDefault(callback.Invoke);
            if (user == null)
            {
                return null;
            }

            _session.SetUser(user);
            return user;
        }

        public User Login(SignInModel model)
        {
            return login(usr => usr.Login.Equals(model.Login) && usr.Password.Equals(model.Password));
        }

        public User SilentLogin()
        {
            if (!PlayerPrefs.HasKey(Utils.AUTH_KEY))
            {
                return null;
            }

            var userId = PlayerPrefs.GetString(Utils.AUTH_KEY);
            var user = login(usr => usr.Id.Equals(userId));
            _session.SetUser(user);
            return user;
        }

        public User Register(SignUpModel model)
        {
            var exists = Login(new SignInModel(model.Login, model.Password));
            if (exists != null)
            {
                return null;
            }

            var userGame = new UserGame(_initialData.Money);
            var user = new User(model.Name, model.Login, model.Password, userGame);
           
            user.Delete();
            user.Update();
            
            _session.SetUser(user);
            return user;
        }
    }
}