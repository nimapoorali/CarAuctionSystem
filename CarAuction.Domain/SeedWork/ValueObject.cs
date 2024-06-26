﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.SeedWork
{
    //Immutable record used for ValueObjects
    public abstract record ValueObject
    {
        protected static bool EqualOperator(ValueObject? left, ValueObject? right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return ReferenceEquals(left, right) || (left is not null && left.Equals(right));
        }
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }
        protected abstract IEnumerable<object?> GetEqualityComponents();

        ////This code block is used for classes and is already implemented for records
        //public override bool Equals(object? obj)
        //{
        //    if (obj == null || obj.GetType() != GetType())
        //    {
        //        return false;
        //    }

        //    var other = (ValueObject)obj;

        //    return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        //}
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        ////This code block is used for classes and is already implemented for records
        //public static bool operator ==(ValueObject one, ValueObject two)
        //{
        //    return EqualOperator(one, two);
        //}

        ////This code block is used for classes and is already implemented for records
        //public static bool operator !=(ValueObject one, ValueObject two)
        //{
        //    return NotEqualOperator(one, two);
        //}
        // Other utility methods

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

        ////Used in domain services for db-related rules
        //protected static void CheckRule<TValue>(IBusinessRule rule, Result<TValue> toResult)
        //{
        //    if (rule.IsBroken())
        //    {
        //        toResult.WithError(rule.Message);
        //    }
        //}
    }
}
