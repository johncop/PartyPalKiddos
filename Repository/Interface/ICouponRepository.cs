using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICouponRepository
    {
        void addCoupon(Coupon d);
        void removeCoupon(Coupon d);
        void UpdateCoupon(Coupon d);
        List<Coupon> GetAllCoupons();
        Coupon GetCouponById(int id);
    }
}
