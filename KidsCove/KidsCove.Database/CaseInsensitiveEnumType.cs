using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Type;
using System.Data;

namespace KidsCove.Database
{


    /// <summary>

    /// Custom NH datatype to map the <see cref="AddressType"/> enum

    /// to db column <c>CustomerAddress.AddressType</c>.

    /// </summary>

    [Serializable]
    public class CaseInsensitiveEnumType<T> : EnumStringType<T>
    {

        #region Overrides



        /// <summary>

        /// This overwrite is actually a bugfix in NH 2.1.

        /// See <see href="http://nhjira.koah.net/browse/NH-1941">NH-1941</see>.

        /// </summary>

        public override void Set(System.Data.IDbCommand cmd, object value, int index)
        {

            var par = (IDataParameter)cmd.Parameters[index];

            if (value == null)
            {

                par.Value = DBNull.Value;

            }

            else
            {
                Type x = typeof(T);
                par.Value = (T)Enum.Parse(x, value.ToString(), true);

            }

        }



        /// <summary>

        /// Gets the string representation for an enum value of type <see cref="AddressType"/>.

        /// </summary>

        /// <param name="enumValue">

        /// The enum value of type <see cref="AddressType"/>.

        /// </param>

        /// <returns>The corresponding string value.</returns>

        //public override object GetValue(object enumValue)
        //{
        //    if (enumValue == null)
        //    {

        //        throw new ArgumentNullException("enumValue");

        //    }
        //    return base.GetValue(enumValue);
        //}



        ///// <summary>

        ///// Gets the enum value of type <see cref="AddressType"/>

        ///// that corresponds to the specified string.

        ///// </summary>

        ///// <param name="value">The string value.</param>

        ///// <returns>

        ///// The corresponding enum value of type <see cref="AddressType"/>.

        ///// </returns>

        public override object GetInstance(object value)
        {

            if (value == null)
            {

                throw new ArgumentNullException("value");

            }
            return Enum.Parse(typeof(T), value.ToString(), true); 
        }



        #endregion // Overrides



    } // class AddressTypeEnumStringType


}
