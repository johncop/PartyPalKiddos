using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CouponDAO
    {
        public static List<Coupon> GetCoupons()
        {
            var listCoupon = new List<Coupon>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listCoupon = context.Coupons
                .Select(coupon => new Coupon
                {
                    Id = coupon.Id,
                    CouponName = coupon.CouponName,
                    DiscountAmount = coupon.DiscountAmount,
                    Description = coupon.Description,
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCoupon;
        }
        public static Coupon findCouponById(int id)
        {
            Coupon p = new Coupon();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Coupons
                .Select(coupon => new Coupon
                {
                    Id = coupon.Id,
                    CouponName = coupon.CouponName,
                    DiscountAmount = coupon.DiscountAmount,
                    Description = coupon.Description,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        public static void SaveCoupon(Coupon coupon)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Coupons.Add(coupon);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteCoupon(Coupon coupon)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.Coupons.SingleOrDefault(x => x.Id == coupon.Id);
                    context.Coupons.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateCoupon(Coupon coupon)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<Coupon>(coupon).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
