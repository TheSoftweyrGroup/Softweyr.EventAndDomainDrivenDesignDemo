// -----------------------------------------------------------------------
// <copyright file="Customer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CQRSTest.WriteModel
{
    using System;
    using System.Linq;

    using CQRSTest.CQRS;
    using CQRSTest.Models.WriteModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Customer
    {
        private static class BusinessRule
        {
            public static class CustomerMustExist
            {
                public static bool IsSatisifedBy(CustomerState state)
                {
                    if (state == CustomerState.Created)
                    {
                        return true;
                    }

                    return false;
                }
            }

            public static class CustomerMustNotAlreadyExist
            {
                public static bool IsSatisifedBy(CustomerState state)
                {
                    if (state == CustomerState.DoesNotExist)
                    {
                        return true;
                    }

                    return false;
                }
            }

            public static class NameMustBeAlphaNumeric
            {
                public static bool IsSatisifedBy(string name)
                {
                    if (name.Any(chr => !char.IsLetterOrDigit(chr)))
                    {
                        return false;
                    }

                    return true;
                }
            }
        }
    }
}
