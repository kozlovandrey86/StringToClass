using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StringToClass
{

  public class Mapper<T>
  {
    T _obj;
    string _inStr;

    public Mapper(T obj, string inStr) { _obj = obj; _inStr = inStr; }
    public Mapper<T> Map<TProp>(Expression<Func<T, TProp>> propertryExp, Expression<Func<string, string>> parseFunc)
    {

      var parseFuncRes = parseFunc.Compile()(_inStr);

      Expression paramExpr = Expression.Constant(parseFuncRes, typeof(TProp));
      BinaryExpression assignExpression = Expression.Assign(propertryExp.Body, paramExpr);

      var lambdaSetter = Expression.Lambda<Action<T>>(assignExpression, new List<ParameterExpression> { propertryExp.Parameters[0] });
      lambdaSetter.Compile().Invoke(_obj);

      return this;
    }
  }
}
