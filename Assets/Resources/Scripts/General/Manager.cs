using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable InconsistentNaming

namespace General
{
    public interface IManager : IUpdatable
    {
        public abstract void Clean();
    }

    /// <summary>
    /// Classes Implementing that interface are Singleton Manager.
    /// </summary>
    public interface IWrapperManager : IManager
    {
    }

    public abstract class Manager : IManager
    {
        public abstract void Init();

        public abstract void PostInit();

        public abstract void Refresh();

        public abstract void FixedRefresh();
        public void LateRefresh()
        {
            
        }

        public abstract void Clean();
    }

    public interface ICollectionManager<in T> where T : IUpdatable
    {
        abstract void Add(T obj);
        public abstract void Remove(T obj);
    }

    public class MonoManager<T> : IManager where T : IUpdatable
    {
        private T _obj;

        public MonoManager(T obj)
        {
            _obj = obj;
        }

        public void Init()
        {
            _obj.Init();
        }

        public void PostInit()
        {
            _obj.PostInit();
        }

        public void Refresh()
        {
            _obj.Refresh();
        }

        public void FixedRefresh()
        {
            _obj.FixedRefresh();
        }

        public void LateRefresh()
        {
            
        }

        public void Clean()
        {
        }
    }

    public abstract class MonoManager<T, M> : Manager, IWrapperManager
        where T : IUpdatable where M : class, IManager, new()
    {
        public T obj { get; protected set; }

        #region Singleton

        private static M instance;
        public static M Instance => instance ??= new M();

        protected MonoManager() { }

        #endregion

        public override void Init()
        {
            if (obj == null)
            {
                Debug.LogWarning("MonoManager " + typeof(M) + " has been initialize with a null object.");
            }
            else obj.Init();
        }

        public override void PostInit()
        {
            obj.PostInit();
        }

        public sealed override void Refresh() 
        {
            obj.Refresh();
        }

        public sealed override void FixedRefresh()
        {
            obj.FixedRefresh();
        }

        public override void Clean()
        {
        }
    }

    /// <summary>
    /// Manager that can manage any collection of any type of object. can be instantiated with the new operator.
    /// </summary>
    /// <typeparam name="T">Type of  the objects to Manage</typeparam>
    public class Manager<T> : IManager, ICollectionManager<T> where T : IUpdatable
    {
        #region Variables & Properties

        private readonly HashSet<T> _collection;
        private readonly Stack<T> ToAdd;
        private readonly Stack<T> ToRemove;

        #endregion

        public Manager()
        {
            _collection = new HashSet<T>();
            ToAdd = new Stack<T>();
            ToRemove = new Stack<T>();
        }

        #region Public Methods

        public void Init()
        {
            AddStackItemsToCollection();
            InitCollection();
        }

        public void PostInit()
        {
            PostInitCollection();
        }

        public void Refresh()
        {
            RemoveStackItemsFromCollection();
            UpdateCollection();
            AddStackItemsToCollection();
        }

        public void FixedRefresh()
        {
            FixedUpdateCollection();
        }

        public void LateRefresh()
        {
            
        }

        public void Add(T item)
        {
            ToAdd.Push(item);
        }

        public void Remove(T item)
        {
            ToRemove.Push(item);
        }

        public void Clean()
        {
            CleanManager();
        }

        #endregion

        #region Protected Method

        /// <summary>
        /// !!!DANGEROUS METHOD!!!
        /// <list type="bullet"><item>
        /// <description>Can be use on Override Init to fill your collection
        /// with objects of type 'T' that are already present on the scene.</description></item>
        /// </list>
        /// If use elsewhere, you could have the same object multiple time
        /// in your collection or some other unintended bug.
        /// </summary>
        /*
         protected void FindAllObjectsOfTypeToCollection()
        {
            var hashSet = new HashSet<T>(Object.FindObjectsOfType<T>().ToList());

            foreach (var item in hashSet)
            {
                Add(item);
            }

            Debug.LogWarning(
                "Be sure this 'FindAllObjectsOfTypeToCollection()' is called during an initialization phase or in other optimal condition");
        }
        */

        #endregion

        #region Private Methods

        private void InitCollection()
        {
            foreach (var item in _collection)
            {
                item.Init();
            }
        }

        private void PostInitCollection()
        {
            foreach (var item in _collection)
            {
                item.PostInit();
            }
        }

        private void AddStackItemsToCollection()
        {
            while (ToAdd.Count > 0)
            {
                _collection.Add(ToAdd.Pop());
            }
        }

        private void RemoveStackItemsFromCollection()
        {
            while (ToRemove.Count > 0)
            {
                _collection.Remove(ToRemove.Pop());
            }
        }

        private void UpdateCollection()
        {
            foreach (var item in _collection)
            {
                item.Refresh();
            }
        }

        private void FixedUpdateCollection()
        {
            foreach (var item in _collection)
            {
                item.FixedRefresh();
            }
        }

        private void CleanManager()
        {
            _collection.Clear();
            ToAdd.Clear();
            ToRemove.Clear();
        }

        #endregion
    }

    /// <summary>
    /// Manager that is a Singleton.
    /// </summary>
    /// <typeparam name="T">Type to Manage</typeparam>
    /// <typeparam name="M">Manager type</typeparam>
    public abstract class Manager<T, M> : Manager, IWrapperManager, ICollectionManager<T>
        where T : IUpdatable where M : class, IManager, new()
    {
        #region Singleton

        private static M instance;
        public static M Instance => instance ??= new M();

        protected Manager()
        {
            manager = new Manager<T>();
        }
        
        #endregion

        #region Variables & Properties

        protected readonly Manager<T> manager;

        #endregion

        public override void Init()
        {
            manager.Init();
        }

        public override void PostInit()
        {
            manager.PostInit();
        }

        public sealed override void Refresh()
        {
            manager.Refresh();
        }

        public sealed override void FixedRefresh()
        {
            manager.FixedRefresh();
        }

        public override void Clean()
        {
            manager.Clean();
        }

        public void Add(T obj)
        {
            manager.Add(obj);
        }

        public void Remove(T obj)
        {
            manager.Remove(obj);
        }
    }

    /// <summary>
    /// Singleton Manager that also contains a Factory using an Object Pool.
    /// Refer Yourself to the class factory&lt;T,E,A&gt; for more information
    /// concerning the factory.
    /// </summary>
    /// <typeparam name="T">Type to Manage</typeparam>
    /// <typeparam name="E">Enum listing different type of 'T' for the factory</typeparam>
    /// <typeparam name="A">Arguments to provide to the factory</typeparam>
    /// <typeparam name="M">Manager Type</typeparam>
    public abstract class Manager<T, E, A, M> : Manager<T, M>, IFactory<T, E, A>
        where T : IUpdatable, ICreatable<A>, IPoolable
        where A : IArgs
        where M : class, IManager, new()
        where E : Enum
    {
        protected Manager()
        {
            if (string.IsNullOrEmpty(PrefabLocation))
                Debug.LogError("The PrefabLocation Property of " + typeof(M) + " has not been set");
            else _factory = new Factory<T, E, A>(PrefabLocation);
        }

        #region Variables & Properties

        protected abstract string PrefabLocation { get; }
        private readonly Factory<T, E, A> _factory;

        #endregion

        public override void Init()
        {
            _factory.Init();
            manager.Init();
        }

        public T Create(Type type, A constructionArgs)
        {
            var toReturn = _factory.Create(type, constructionArgs);
            manager.Add(toReturn);
            return toReturn;
        }
    }
}