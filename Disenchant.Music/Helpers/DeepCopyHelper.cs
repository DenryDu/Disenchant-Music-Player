using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Disenchant.Music.Helpers
{
    internal class DeepCopyHelper
    {
        /// <summary>
        /// 反射
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public static class TransReflection<TIn, TOut>
        {
            public static TOut Trans(TIn tIn)
            {

                TOut tOut = Activator.CreateInstance<TOut>();
                var tInType = tIn.GetType();
                foreach (var itemOut in tOut.GetType().GetProperties())
                {
                    var itemIn = tInType.GetProperty(itemOut.Name); ;
                    if (itemIn != null)
                    {
                        itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                    }
                }
                return tOut;

            }
        }
        /// <summary>
        /// Json 序列化和反序列化（不适合含有BitmapImage这种不可序列化对象的类）
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        public static class TransJson<TIn, TOut>
        {
            public static TOut Trans(TIn tIn)
            {
                return JsonSerializer.Deserialize<TOut>(JsonSerializer.Serialize(tIn));
            }
        }
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        public static class TransBinary<TIn, TOut>
        {
            public static TOut Trans(TIn tIn)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, tIn);
                    ms.Position = 0;
                    return (TOut)formatter.Deserialize(ms);
                }
            }
        }
        /// <summary>
        /// AutoMapper
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        public static class TransMapper<TIn, TOut>
        {
            //public static TOut Trans(TIn tIn)
            //{
            //循环外创建MapperConfig
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, UserInfo>());
            //var mapper = config.CreateMapper();

            //循环内调用
            //return mapper.Map<TOut>(tIn);
            //}

        }
        /// <summary>
        /// 表达式树
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        public static class TransExp<TIn, TOut>
        {
            private static readonly Func<TIn, TOut> cache = GetFunc();
            private static Func<TIn, TOut> GetFunc()
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();

                foreach (var item in typeof(TOut).GetProperties())
                {
                    if (!item.CanWrite) continue;
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }

                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
                Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

                return lambda.Compile();
            }

            public static TOut Trans(TIn tIn)
            {
                return cache(tIn);
            }
        }
    }
}
