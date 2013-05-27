//using System;
//using System.ServiceModel;

//namespace Hit.Stores
//{
//    public static class ContextContainer
//    {
//        public static T Find<T>() where T : ContextExtensionBase
//        {
//            if (OperationContext.Current != null)
//            {
//                return OperationContext.Current.Extensions.Find<T>();
//            }

//            //if (HttpContext.Current != null)
//            //{
//            //    if (!HttpContext.Current.Items.Contains(typeof(T).Name))
//            //    {
//            //        return null;
//            //    }

//            //    return HttpContext.Current.Items[typeof(T).Name] as T;
//            //}

//            throw new NotSupportedException();
//        }

//        public static void Add(ContextExtensionBase value)
//        {
//            if (value == null)
//            {
//                throw new ArgumentNullException("value");
//            }

//            if (OperationContext.Current != null)
//            {
//                OperationContext.Current.Extensions.Add(value);
//            }
//            //else if (HttpContext.Current != null)
//            //{
//            //    HttpContext.Current.Items[value.GetType().Name] = value;
//            //}
//            else
//            {
//                throw new NotSupportedException();
//            }
//        }
//    }

//    public abstract class ContextExtensionBase : IExtension<OperationContext>
//    {
//        #region IExtension<OperationContext> Members

//        public void Attach(OperationContext owner)
//        {
//            owner.OperationCompleted += (sender, args) => this.Detach((OperationContext)sender);
//        }

//        public void Detach(OperationContext owner)
//        {

//        }

//        #endregion
//    }
//}
