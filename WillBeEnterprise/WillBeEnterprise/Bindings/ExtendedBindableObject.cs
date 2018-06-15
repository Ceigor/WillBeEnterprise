using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace WillBeEnterprise.Bindings
{
    public class ExtendedBindableObject : BindableObject
    {
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            Debug.WriteLine("Raising property changed event for name = " + name);
            OnPropertyChanged(name);
        }

        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression == null)
                operand = (MemberExpression)lambdaExpression.Body;
            else
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            return operand.Member;
        }
    }
}
