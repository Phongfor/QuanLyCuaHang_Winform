DECLARE @Counter INT = 1;

-- Danh sách họ
DECLARE @Ho TABLE (Ho NVARCHAR(50));
INSERT INTO @Ho VALUES (N'Nguyễn'), (N'Lê'), (N'Trần'), (N'Phạm'), (N'Hoàng'), (N'Huỳnh'), (N'Phan'), (N'Vũ'), (N'Võ');

-- Danh sách tên đệm
DECLARE @Dem TABLE (Dem NVARCHAR(50));
INSERT INTO @Dem VALUES (N'Văn'), (N'Thị'), (N'Minh'), (N'Hồng'), (N'Thanh'), (N'Thảo'), (N'Quốc'), (N'Nhật'), (N'Tú');

-- Danh sách tên
DECLARE @Ten TABLE (Ten NVARCHAR(50));
INSERT INTO @Ten VALUES (N'Hùng'), (N'Trung'), (N'Trang'), (N'Lan'), (N'Phương'), (N'Tú'), (N'Nam'), (N'Huy'), (N'Trường');

WHILE @Counter <= 100
BEGIN
    -- Mã khách hàng
    DECLARE @MaKH INT = @Counter;

    -- Tạo số điện thoại hợp lệ
    DECLARE @Prefix NVARCHAR(2) = 
        CASE ABS(CHECKSUM(NEWID())) % 3
            WHEN 0 THEN '07'
            WHEN 1 THEN '08'
            ELSE '09'
        END;
    
    DECLARE @RandomNumber NVARCHAR(8) = CAST(1000000 + ABS(CHECKSUM(NEWID())) % 9000000 AS NVARCHAR);
    DECLARE @SDTKH NVARCHAR(10) = CONCAT(@Prefix, @RandomNumber);

    -- Chọn ngẫu nhiên họ, tên đệm, tên từ danh sách
    DECLARE @HoRandom NVARCHAR(50) = (SELECT TOP 1 Ho FROM @Ho ORDER BY NEWID());
    DECLARE @DemRandom NVARCHAR(50) = (SELECT TOP 1 Dem FROM @Dem ORDER BY NEWID());
    DECLARE @TenRandom NVARCHAR(50) = (SELECT TOP 1 Ten FROM @Ten ORDER BY NEWID());

    -- Tạo họ tên đầy đủ
    DECLARE @TenKH NVARCHAR(100) = CONCAT(@HoRandom, ' ', @DemRandom, ' ', @TenRandom);

    -- Chèn dữ liệu vào bảng
    INSERT INTO tblKhachHang (MaKH, TenKH, SDTKH)
    VALUES (@MaKH, @TenKH, @SDTKH);

    -- Tăng bộ đếm
    SET @Counter = @Counter + 1;
END;

-------------------------------------------------------------
-- Danh sách địa chỉ mẫu
DECLARE @DiaChi TABLE (DiaChi NVARCHAR(255));
INSERT INTO @DiaChi VALUES
(N'123 Lê Lợi, Quận 1, TP.HCM'),
(N'45 Trần Hưng Đạo, Quận 5, TP.HCM'),
(N'789 Nguyễn Huệ, Quận 1, TP.HCM'),
(N'56 Lý Thường Kiệt, Quận Tân Bình, TP.HCM'),
(N'90 Phạm Văn Đồng, TP. Thủ Đức, TP.HCM'),
(N'12 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM'),
(N'34 Hoàng Văn Thụ, Quận Phú Nhuận, TP.HCM'),
(N'67 Nguyễn Trãi, Quận 5, TP.HCM'),
(N'78 Hai Bà Trưng, Quận 3, TP.HCM'),
(N'99 Võ Văn Kiệt, Quận 1, TP.HCM');

-- Chèn ngẫu nhiên 1 - 3 địa chỉ cho mỗi khách hàng
INSERT INTO tblDiaChi_KhachHang (MaKH, DiaChi)
SELECT MaKH, DiaChi
FROM tblKhachHang 
CROSS JOIN (SELECT TOP 3 DiaChi FROM @DiaChi ORDER BY NEWID()) AS RandomDiaChi;

-------------------------------------------------------------------------
INSERT INTO tblDanhMuc (MaDanhMuc, TenDanhMuc) VALUES
(1, N'Cà phê rang xay'),
(2, N'Cà phê hòa tan'),
(3, N'Hạt cà phê nguyên chất'),
(4, N'Cà phê đặc sản'),
(5, N'Dụng cụ pha chế'),
(6, N'Phin và máy pha cà phê'),
(7, N'Sữa và topping'),
(8, N'Combo quà tặng'),
(9, N'Trà và các loại đồ uống khác');
----------------------------------------------

INSERT INTO tblMonAn (MaMon, TenMon, MoTa, Gia, Donvitinh, MaDanhMuc) VALUES
(1, N'Cà phê đen', N'Cà phê nguyên chất', 25000, N'Ly', 1),
(2, N'Cà phê sữa', N'Cà phê + sữa đặc', 30000, N'Ly', 1),
(3, N'Capuchino', N'Cà phê Ý', 50000, N'Ly', 1),
(4, N'Trà sữa trân châu', N'Trà sữa + trân châu', 40000, N'Ly', 9),
(5, N'Bánh Croissant', N'Bánh ngọt Pháp', 35000, N'Cái', 8),
(6, N'Matcha Latte', N'Trà xanh + sữa', 45000, N'Ly', 9),
(7, N'Moka đá xay', N'Cà phê Moka', 55000, N'Ly', 1),
(8, N'Cà phê hòa tan 3in1', N'Gói cà phê tiện lợi', 12000, N'Gói', 2),
(9, N'Bánh Tiramisu', N'Bánh kem Ý', 60000, N'Cái', 8),
(10, N'Espresso', N'Cà phê đậm đặc', 40000, N'Ly', 1);

----------------------------------------------------------
INSERT INTO tblNhanVien (MaNV, TenNV, SDTNV, NgayVaoLam, TaiKhoan, MatKhau, PhanQuyen) VALUES
(1, N'Nguyễn Văn An', '0987654321', '2023-01-15', 'nguyenvanan', '123456', 'Admin'),
(2, N'Trần Thị Bích Ngọc', '0912345678', '2022-11-20', 'tranbichngoc', '654321', 'Nhân viên'),
(3, N'Hoàng Văn Cường', '0909876543', '2023-05-10', 'hoangvancuong', 'password', 'Nhân viên'),
(4, N'Phạm Thị Dung', '0965432109', '2021-09-30', 'phamthidung', 'admin123', 'Admin'),
(5, N'Lê Văn Hoàng', '0932109876', '2022-07-12', 'levanhoang', 'nv5678', 'Nhân viên'),
(6, N'Đặng Thị Hương', '0923456789', '2023-03-18', 'dangthihuong', 'mypass', 'Nhân viên'),
(7, N'Bùi Quang Huy', '0976543210', '2020-12-05', 'buiquanghuy', 'huy12345', 'Nhân viên'),
(8, N'Vũ Thị Lan Anh', '0954321876', '2019-08-25', 'vuthilananh', 'lananh789', 'Nhân viên'),
(9, N'Đỗ Mạnh Hùng', '0945671234', '2021-06-15', 'domanhhung', 'hungpass', 'Nhân viên'),
(10, N'Ngô Thị Kim Chi', '0934567890', '2022-04-10', 'ngothikimchi', 'kimchi999', 'Nhân viên');
-----------------------------------------------------------------
SET DATEFORMAT dmy;

INSERT INTO tblDonHang (MaDonHang, MaNV, NgayDat, NgayThanhToan, TrangThai, Loai, GiamGia, TongTien)
VALUES 
(1, 1, CONVERT(DATETIME, '01/02/2025 08:30:00', 103), CONVERT(DATETIME, '01/02/2025 09:00:00', 103), N'Hoàn thành', N'Giao hàng', '10%', 450000.00),
(2, 2, CONVERT(DATETIME, '02/02/2025 10:45:00', 103), CONVERT(DATETIME, '02/02/2025 11:30:00', 103), N'Hoàn thành', N'Tại chỗ', '5%', 250000.00),
(3, 3, CONVERT(DATETIME, '03/02/2025 12:00:00', 103), NULL, N'Chờ xác nhận', N'Giao hàng', '0%', 320000.00),
(4, 4, CONVERT(DATETIME, '04/02/2025 14:15:00', 103), NULL, N'Đang xử lý', N'Giao hàng', '20%', 180000.00),
(5, 5, CONVERT(DATETIME, '05/02/2025 16:45:00', 103), CONVERT(DATETIME, '05/02/2025 17:20:00', 103), N'Hoàn thành', N'Tại chỗ', '15%', 500000.00),
(6, 1, CONVERT(DATETIME, '06/02/2025 09:30:00', 103), CONVERT(DATETIME, '06/02/2025 10:15:00', 103), N'Hoàn thành', N'Giao hàng', '0%', 290000.00),
(7, 2, CONVERT(DATETIME, '07/02/2025 13:20:00', 103), NULL, N'Chờ xác nhận', N'Giao hàng', '10%', 230000.00),
(8, 3, CONVERT(DATETIME, '08/02/2025 15:00:00', 103), CONVERT(DATETIME, '08/02/2025 15:40:00', 103), N'Hoàn thành', N'Tại chỗ', '5%', 400000.00),
(9, 4, CONVERT(DATETIME, '09/02/2025 18:10:00', 103), NULL, N'Đang xử lý', N'Giao hàng', '0%', 270000.00),
(10, 5, CONVERT(DATETIME, '10/02/2025 20:30:00', 103), CONVERT(DATETIME, '10/02/2025 21:00:00', 103), N'Hoàn thành', N'Giao hàng', '15%', 360000.00),
(11, 1, CONVERT(DATETIME, '11/02/2025 07:50:00', 103), CONVERT(DATETIME, '11/02/2025 08:20:00', 103), N'Hoàn thành', N'Tại chỗ', '5%', 150000.00),
(12, 2, CONVERT(DATETIME, '12/02/2025 10:10:00', 103), NULL, N'Chờ xác nhận', N'Giao hàng', '10%', 330000.00),
(13, 3, CONVERT(DATETIME, '13/02/2025 12:25:00', 103), CONVERT(DATETIME, '13/02/2025 13:00:00', 103), N'Hoàn thành', N'Giao hàng', '0%', 290000.00),
(14, 4, CONVERT(DATETIME, '14/02/2025 14:50:00', 103), NULL, N'Đang xử lý', N'Giao hàng', '20%', 220000.00),
(15, 5, CONVERT(DATETIME, '15/02/2025 17:10:00', 103), CONVERT(DATETIME, '15/02/2025 18:00:00', 103), N'Hoàn thành', N'Tại chỗ', '15%', 450000.00);

SET DATEFORMAT dmy;

INSERT INTO tblDonHang (MaDonHang, MaNV, NgayDat, NgayThanhToan, TrangThai, Loai, GiamGia, TongTien)
VALUES 
(16, 2, CONVERT(DATETIME, '16/02/2025 09:20:00', 103), CONVERT(DATETIME, '16/02/2025 10:00:00', 103), N'Hoàn thành', N'Giao hàng', '10%', 320000.00),
(17, 3, CONVERT(DATETIME, '17/02/2025 12:45:00', 103), NULL, N'Chờ xác nhận', N'Tại chỗ', '5%', 280000.00),
(18, 4, CONVERT(DATETIME, '18/02/2025 14:10:00', 103), CONVERT(DATETIME, '18/02/2025 14:50:00', 103), N'Hoàn thành', N'Giao hàng', '15%', 410000.00),
(19, 5, CONVERT(DATETIME, '19/02/2025 16:30:00', 103), NULL, N'Đang xử lý', N'Giao hàng', '0%', 360000.00),
(20, 1, CONVERT(DATETIME, '20/02/2025 18:15:00', 103), CONVERT(DATETIME, '20/02/2025 19:00:00', 103), N'Hoàn thành', N'Tại chỗ', '20%', 500000.00),
(21, 2, CONVERT(DATETIME, '21/02/2025 07:50:00', 103), CONVERT(DATETIME, '21/02/2025 08:30:00', 103), N'Hoàn thành', N'Giao hàng', '10%', 150000.00),
(22, 3, CONVERT(DATETIME, '22/02/2025 10:30:00', 103), NULL, N'Chờ xác nhận', N'Tại chỗ', '5%', 270000.00),
(23, 4, CONVERT(DATETIME, '23/02/2025 13:20:00', 103), CONVERT(DATETIME, '23/02/2025 14:10:00', 103), N'Hoàn thành', N'Giao hàng', '0%', 330000.00),
(24, 5, CONVERT(DATETIME, '24/02/2025 15:45:00', 103), NULL, N'Đang xử lý', N'Giao hàng', '10%', 290000.00),
(25, 1, CONVERT(DATETIME, '25/02/2025 18:00:00', 103), CONVERT(DATETIME, '25/02/2025 18:50:00', 103), N'Hoàn thành', N'Tại chỗ', '15%', 480000.00),
(26, 2, CONVERT(DATETIME, '26/02/2025 09:40:00', 103), NULL, N'Chờ xác nhận', N'Giao hàng', '5%', 250000.00),
(27, 3, CONVERT(DATETIME, '27/02/2025 11:20:00', 103), CONVERT(DATETIME, '27/02/2025 12:10:00', 103), N'Hoàn thành', N'Tại chỗ', '0%', 350000.00),
(28, 4, CONVERT(DATETIME, '28/02/2025 13:55:00', 103), NULL, N'Đang xử lý', N'Giao hàng', '10%', 310000.00),
(29, 5, CONVERT(DATETIME, '01/03/2025 16:10:00', 103), CONVERT(DATETIME, '01/03/2025 16:50:00', 103), N'Hoàn thành', N'Giao hàng', '20%', 420000.00),
(30, 1, CONVERT(DATETIME, '02/03/2025 18:30:00', 103), NULL, N'Chờ xác nhận', N'Tại chỗ', '15%', 400000.00);

---------------------------------------------------------------------------------------------------------
INSERT INTO [dbo].[tblChiTietDonHang](MaDonHang, MaMon, SoLuong, Gia)
VALUES
-- Đơn hàng 1: 2 món
(1, 1, 2, 25000.00),  -- Cà phê đen (2 ly)
(1, 3, 1, 50000.00),  -- Capuchino (1 ly)

-- Đơn hàng 2: 3 món
(2, 2, 3, 30000.00),  -- Cà phê sữa (3 ly)
(2, 4, 2, 40000.00),  -- Trà sữa trân châu (2 ly)
(2, 5, 1, 35000.00),  -- Bánh Croissant (1 cái)

-- Đơn hàng 3: 2 món
(3, 9, 2, 60000.00),  -- Bánh Tiramisu (2 cái)
(3, 6, 1, 45000.00),  -- Matcha Latte (1 ly)

-- Đơn hàng 4: 1 món
(4, 10, 1, 40000.00), -- Espresso (1 ly)

-- Đơn hàng 5: 3 món
(5, 7, 3, 55000.00),  -- Moka đá xay (3 ly)
(5, 8, 2, 12000.00),  -- Cà phê hòa tan 3in1 (2 gói)
(5, 1, 1, 25000.00),  -- Cà phê đen (1 ly)

-- Đơn hàng 6: 2 món
(6, 2, 2, 30000.00),  -- Cà phê sữa (2 ly)
(6, 3, 1, 50000.00),  -- Capuchino (1 ly)

-- Đơn hàng 7: 3 món
(7, 4, 1, 40000.00),  -- Trà sữa trân châu (1 ly)
(7, 9, 2, 60000.00),  -- Bánh Tiramisu (2 cái)
(7, 5, 1, 35000.00),  -- Bánh Croissant (1 cái)

-- Đơn hàng 8: 2 món
(8, 6, 1, 45000.00),  -- Matcha Latte (1 ly)
(8, 10, 1, 40000.00), -- Espresso (1 ly)

-- Đơn hàng 9: 2 món
(9, 7, 2, 55000.00),  -- Moka đá xay (2 ly)
(9, 8, 3, 12000.00);  -- Cà phê hòa tan 3in1 (3 gói)

--------------------------------------------------------------

INSERT INTO tblGiaoHang (MaDonHang, TenNguoiGiao, SDTNguoiGiao, TrangThai, GhiChu, NgayBatDau, NgayKetThuc, MaKH)
VALUES 
(1, N'Nguyễn Văn An', '0987654321', N'Đã giao', N'Giao hàng thành công', CONVERT(DATETIME, '01/02/2025 08:45:00', 103), CONVERT(DATETIME, '01/02/2025 09:00:00', 103), 3),
(3, N'Trần Minh Bảo', '0976543210', N'Đang giao', N'Giao chậm do kẹt xe', CONVERT(DATETIME, '03/02/2025 12:10:00', 103), NULL, 4),
(4, N'Phạm Thị Cẩm Tú', '0965432109', N'Chuẩn bị giao', N'Chờ xác nhận từ khách hàng', CONVERT(DATETIME, '04/02/2025 14:30:00', 103), NULL, 5),
(6, N'Lê Hoàng Dũng', '0954321098', N'Đã giao', N'Giao hàng nhanh', CONVERT(DATETIME, '06/02/2025 09:40:00', 103), CONVERT(DATETIME, '06/02/2025 10:10:00', 103), 6),
(7, N'Hoàng Gia Huy', '0943210987', N'Đang giao', N'Khách yêu cầu giao sớm', CONVERT(DATETIME, '07/02/2025 13:30:00', 103), NULL, 7),
(9, N'Vũ Quốc Phong', '0932109876', N'Chuẩn bị giao', N'Đơn hàng lớn, cần thêm thời gian', CONVERT(DATETIME, '09/02/2025 18:20:00', 103), NULL, 8),
(10, N'Đặng Bảo Long', '0921098765', N'Đã giao', N'Giao hàng thành công', CONVERT(DATETIME, '10/02/2025 20:40:00', 103), CONVERT(DATETIME, '10/02/2025 21:00:00', 103), 9),
(12, N'Nguyễn Thanh Hưng', '0910987654', N'Đang giao', N'Giao đến trong 10 phút', CONVERT(DATETIME, '12/02/2025 10:20:00', 103), NULL, 10),
(14, N'Lý Hải Quân', '0909876543', N'Chuẩn bị giao', N'Đang lấy hàng', CONVERT(DATETIME, '14/02/2025 15:00:00', 103), NULL, 11),
(15, N'Tôn Thất Kiệt', '0898765432', N'Đã giao', N'Giao hàng thành công', CONVERT(DATETIME, '16/02/2025 08:40:00', 103), CONVERT(DATETIME, '16/02/2025 09:00:00', 103), 12),
(2, N'Văn Kiệt Nguyên', '0887654321', N'Đang giao', N'Giao trong vòng 30 phút', CONVERT(DATETIME, '18/02/2025 12:10:00', 103), NULL, 13),
(8, N'Đỗ Minh Quang', '0876543210', N'Đã giao', N'Hoàn tất đơn hàng', CONVERT(DATETIME, '20/02/2025 16:50:00', 103), CONVERT(DATETIME, '20/02/2025 17:10:00', 103), 14);

---------------------------------------------------------------------------------
INSERT INTO tblDiaChi_KhachHang (MaKH, DiaChi)
VALUES 
(3, N'123 Đường Lê Lợi, Quận 1, TP.HCM'),
(4, N'45 Đường Nguyễn Trãi, Quận 5, TP.HCM'),
(5, N'789 Đường Trần Hưng Đạo, Quận 10, TP.HCM'),
(6, N'56 Đường Hoàng Văn Thụ, Quận Phú Nhuận, TP.HCM'),
(7, N'99 Đường Lý Tự Trọng, Quận 1, TP.HCM'),
(8, N'22 Đường Điện Biên Phủ, Quận Bình Thạnh, TP.HCM'),
(9, N'77 Đường Nguyễn Văn Cừ, Quận 5, TP.HCM'),
(10, N'88 Đường Võ Văn Kiệt, Quận 1, TP.HCM'),
(11, N'111 Đường Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM'),
(12, N'222 Đường Phạm Văn Đồng, Quận Gò Vấp, TP.HCM'),
(13, N'333 Đường Lê Văn Sỹ, Quận 3, TP.HCM'),
(14, N'444 Đường Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM');


