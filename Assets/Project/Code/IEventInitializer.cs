using System;

namespace Assets.Project.Code
{
    public interface IEventInitializer<T> where T : Delegate
    {
        public void AddObserver(T @delegate);
        public void RemoveObserver(T @delegate);
    }
}