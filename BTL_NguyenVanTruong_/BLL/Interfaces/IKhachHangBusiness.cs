﻿using BTL_NguyenVanTruong_.Models;

namespace BTL_NguyenVanTruong_.BLL.Interfaces
{
    public partial interface IKhachHangBusiness
    {
        bool CreateCustomer(KhachHangModel model);
        bool UpdateCustomer(KhachHangModel model);
        KhachHangModel GetCustomerByID(int id);
        bool DeleteCustomer(int id);
        List<KhachHangModel> GetAllKhachHangs();
        List<KhachHangModel> SearchKhachHang(int pageIndex, int pageSize, out long total, string tenkh, string diachi);
    }
}
