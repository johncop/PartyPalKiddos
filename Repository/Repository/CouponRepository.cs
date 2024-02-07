using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CouponRepository : ICouponRepository
    {
        public void addCoupon(Coupon coupon) => CouponDAO.SaveCoupon(coupon);

        public List<Coupon> GetAllCoupons() => CouponDAO.GetCoupons();

        public Coupon GetCouponById(int id) => CouponDAO.findCouponById(id);

        public void removeCoupon(Coupon coupon) => CouponDAO.DeleteCoupon(coupon);

        public void UpdateCoupon(Coupon coupon) => CouponDAO.UpdateCoupon(coupon);
    }
}
