create database BaoHiemNhanTho
go
use BaoHiemNhanTho
go

create table LoaiBH
(
	MaLoaiBH char(10) primary key not null,
	TenLoaiBH nvarchar(50)
)

create table SanPham
(
	MaSP char(10) primary key not null,
	TenSP nvarchar(50),
	DoTuoiThamGia nvarchar(20),
	MaLoaiBH char(10),
	GiaSP bigint,
	constraint fk_loaisp_sp foreign key (MaLoaiBH) references LoaiBH(MaLoaiBH)
)


create table Ctylienket
(
	MaCTLK char(10) primary key not null,
	TenCT nvarchar(50),
	DiaChi nvarchar(100),
	Linhvuc nvarchar(50),
	SDT char(12)
)

create table ChiNhanh
(
    MaCN char(10) primary key not null,
	Tenchinhanh nvarchar(50),
	Khuvuc nvarchar(30),
	TinhTP nvarchar(30),
	Diachi nvarchar(100),
	SDT char(12),
)

create table Lienket
(
	MaCN char (10) ,
	MaCTLK char(10),
	primary key (MaCN,MaCTLK),
	constraint fk_lk_ctlk foreign key (MaCTLK) references Ctylienket(MaCTLK),
	constraint fk_lk_cn foreign key (MaCN) references Chinhanh(MaCN)
)

create table KH_MBM
(
	MaKH_MBM char(10) primary key  not null,
	TenKH_MBM nvarchar(50),
	Namsinh int,
	GioiTinh nvarchar(10),
	DiaChi nvarchar(100),
	CMND char(15),
	NgheNghiep nvarchar(50),
	NguoiDuocBaoHiem nvarchar(50),
)

create table NhanVien
(
	MaNV char(10) primary key not null,
	TenNV nvarchar(50),
	NgaySinh date,
	GioiTinh nvarchar(10),
	MaCN char(10),
	constraint fk_nv_ct foreign key (MaCN) references ChiNhanh(MaCN)
)

create table HoaDon
(
	MaHD char(10) primary key not null,
	MaKH_MBM char(10) not null,
	MaNV char(10) not null,
	NgayThangNam date,
	HinhThucDongTienBH nvarchar(10),
	constraint fk_hd_nv foreign key (MaNV) references NhanVien(MaNV),
	constraint fk_hd_khmbm foreign key(MaKH_MBM) references KH_MBM(MaKH_MBM),
)

create table ChiTietHoaDon
(
	MaHD char(10) not null,
	MaSP char(10) not null,
	ThoiHanBH int,
	ThoiHanDongTien int,
	PhiTienBH int,
	SoTienCanDong bigint,
	TongTienBH bigint,
	primary key(MaHD, MaSP),
	constraint fk_cthd_hd foreign key (MaHD) references HoaDon(MaHD),
	constraint fk_cthd_sp foreign key (MaSP) references SanPham(MaSP)
)

set dateformat dmy
insert into LoaiBH(MaLoaiBH, TenLoaiBH) values ('BH001', N'Tích lũy')
insert into LoaiBH(MaLoaiBH, TenLoaiBH) values ('BH002', N'Bảo vệ')
insert into LoaiBH(MaLoaiBH, TenLoaiBH) values ('BH003', N'Đầu tư')
insert into LoaiBH(MaLoaiBH, TenLoaiBH) values ('BH004', N'Hưu trí')
insert into LoaiBH(MaLoaiBH, TenLoaiBH) values ('BH005', N'Doanh nghiệp') 
select * from LoaiBH

insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP001', N'An Khoa Trạng Nguyên', N'Từ 0-15 tuổi', 'BH001', 28416800)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP002', N'An Hưng Phát Lộc', N'Từ 0-60 tuổi', 'BH001', 21929000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP003', N'An Phát Cát Tường', N'Từ 0-65 tuổi', 'BH002', 25000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP004', N'Trọn Đời Yêu Thương', N'Từ 0-65 tuổi', 'BH002', 30000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP005', N'An Bình Thịnh Vượng', N'Từ 18-60 tuổi', 'BH002', 16121000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP006', N'An Phát Bảo Gia', N'Từ 1-60 tuổi', 'BH002', 30000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP007', N'An Phát Trọn Đời', N'Từ 0-60 tuổi', 'BH003', 30000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP008', N'An Tâm Học Vấn', N'Từ 0-14 tuổi', 'BH003', 50000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP009', N'An Phát Hưng Gia', N'Từ 0-60 tuổi', 'BH003', 30000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP010', N'An Phúc Gia Lộc', N'Từ 0-60 tuổi', 'BH003', 50000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP011', N'An Sinh Giáo Dục', N'Từ 0-15 tuổi', 'BH003', 20680000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP012', N'Hưu Trí An Khang', N'Từ 15-65 tuổi', 'BH004', 12000000)
insert into SanPham(MaSP, TenSP, DoTuoiThamGia, MaLoaiBH, GiaSP) values ('SP013', N'Hưu trí Vững Nghiệp', N'Từ 15-65 tuổi', 'BH005', 20000000) 
select * from SanPham

insert into Ctylienket(MaCTLK, TenCT, DiaChi, Linhvuc, SDT) values ('CT001',N'Công ty CP Đầu tư và Xây dựng Quốc tế VIGEBA',N'72/Trần Hưng Đạo/Q.Hoàn Kiếm/Hà Nội',N'Bất Động Sản','095678884322')
insert into Ctylienket(MaCTLK, TenCT, DiaChi, Linhvuc, SDT) values ('CT002',N'Công ty CP Đầu tư và Xây dựng Long Việt',N'11/Quang Trung/DakLak',N'Xây Dựng','094376885322')
insert into Ctylienket(MaCTLK, TenCT, DiaChi, Linhvuc, SDT) values ('CT003',N'Công ty CP Đầu tư SCIC',N'71/Ngô Sỹ Liên/Q.Đống Đa/Hà Nội',N'Bất Động Sản','094376885322')
insert into Ctylienket(MaCTLK, TenCT, DiaChi, Linhvuc, SDT) values ('CT004',N'Công ty CP Trung Nam Phú Quốc',N'24/Trần Hưng Đạo/Đà Nẵng',N'Dịch Vụ Ngân Hàng','094373285122')
insert into Ctylienket(MaCTLK, TenCT, DiaChi, Linhvuc, SDT) values ('CT005',N'Công ty CP CNTT PLT',N'43/Thành Thái/Q.10/TP.HCM',N'Dịch vụ Du Lịch Nghỉ Dưỡng','094376885399')
insert into Ctylienket(MaCTLK, TenCT, DiaChi, Linhvuc, SDT) values ('CT006',N'Ngân hàng TMCP Bảo Việt',N'33/Nguyễn Thị Minh Khai/Q.5/TP.HCM',N'Dịch Vụ CNTT Viễn Thông','09437775322')
select * from Ctylienket

insert into ChiNhanh(MaCN, Tenchinhanh, Khuvuc, TinhTP, Diachi, SDT) values ('CN001', N'Tổng Công ty Bảo hiểm Bảo Việt',N'Miền Bắc',N'Hà Nội',N'104/Trần Hưng Đạo/Q.Hoàn Kiếm/Hà Nội','094336285722')
insert into ChiNhanh(MaCN, Tenchinhanh, Khuvuc, TinhTP, Diachi, SDT) values ('CN002', N'Tổng Công ty Bảo Việt Nhân Thọ',N'Miền Bắc',N'Hà Nội',N'72/Trần Hưng Đạo/Q.Hoàn Kiếm/Hà Nội','094478285723')
insert into ChiNhanh(MaCN, Tenchinhanh, Khuvuc, TinhTP, Diachi, SDT) values ('CN003', N'Công ty TNHH Quản lý Bảo Việt',N'Miền Trung',N'Đà Nẵng',N'128/Ngô Quyền/Đà Nẵng','093128285723')
insert into ChiNhanh(MaCN, Tenchinhanh, Khuvuc, TinhTP, Diachi, SDT) values ('CN004', N'Công ty CP chứng khoán Bảo Việt',N'Miền Nam',N'Hồ Chí Minh',N'57/Tô Hiến Thành/Q10/TP.HCM','094456757433')
insert into ChiNhanh(MaCN, Tenchinhanh, Khuvuc, TinhTP, Diachi, SDT) values ('CN005', N'Công ty TNHH một thành viên Bảo Việt',N'Miền Trung',N'Lâm Đồng',N'57/Lê Lai/Đà Lạt','094424285725')
select * from ChiNhanh

insert into Lienket(MaCN, MaCTLK) values ('CN001', 'CT001')
insert into Lienket(MaCN, MaCTLK) values ('CN001', 'CT002')
insert into Lienket(MaCN, MaCTLK) values ('CN002', 'CT003')
insert into Lienket(MaCN, MaCTLK) values ('CN002', 'CT004')
select * from Lienket

insert into KH_MBM(MaKH_MBM, TenKH_MBM, Namsinh, GioiTinh, DiaChi, CMND, NgheNghiep, NguoiDuocBaoHiem) 
values ('KHM001', N'Trần Văn Cảnh', 1986, N'Nam', N'Hồ Chí Minh', '12256789', N'Cán Bộ CNV', N'Trần Văn An')
insert into KH_MBM(MaKH_MBM, TenKH_MBM, Namsinh, GioiTinh, DiaChi, CMND, NgheNghiep, NguoiDuocBaoHiem) 
values ('KHM002', N'Nguyễn Văn Thịnh', 1983, N'Nam', N'Đà Nẵng', '12329798', N'Bác Sĩ', N'Nguyễn Thanh Bình')
insert into KH_MBM(MaKH_MBM, TenKH_MBM, Namsinh, GioiTinh, DiaChi, CMND, NgheNghiep, NguoiDuocBaoHiem) 
values ('KHM003', N'Nguyễn Thị Chi', 1998, N'Nữ', N'Hồ Chí Minh', '122456987', N'Mua Bán', N'Nguyễn Thị Chi')
insert into KH_MBM(MaKH_MBM, TenKH_MBM, Namsinh, GioiTinh, DiaChi, CMND, NgheNghiep, NguoiDuocBaoHiem) 
values ('KHM004', N'Trần Nguyễn Duy', 1995, N'Nam', N'Cà Mau', '123480789', N'Bảo Vệ', N'Trần Nguyễn Duy')
insert into KH_MBM(MaKH_MBM, TenKH_MBM, Namsinh, GioiTinh, DiaChi, CMND, NgheNghiep, NguoiDuocBaoHiem) 
values ('KHM005', N'Trần Văn Đan', 1982, N'Nam', N'Đà Lạt', '123654289', N'Công nhân', N'Trần Văn Nam')
select * from KH_MBM

insert into NhanVien(MaNV ,TenNV, NgaySinh,GioiTinh,MaCN) values
('NV001',N'Nguyễn Trọng Hoàng','20/11/1993',N'Nam','CN001')
insert into NhanVien(MaNV ,TenNV, NgaySinh,GioiTinh,MaCN) values
('NV002',N'Lê Văn Kiên','2/3/1993',N'Nam','CN001')
insert into NhanVien(MaNV ,TenNV, NgaySinh,GioiTinh,MaCN) values
('NV003',N'Nguyễn Kim Anh','14/8/1994',N'Nữ','CN001')
insert into NhanVien(MaNV ,TenNV, NgaySinh,GioiTinh,MaCN) values
('NV004',N'Lê Thị Ái','22/10/1997',N'Nữ','CN002')
insert into NhanVien(MaNV ,TenNV, NgaySinh,GioiTinh,MaCN) values
('NV005',N'Nguyễn Kim Trọng','13/1/1995',N'Nam','CN002')
insert into NhanVien(MaNV ,TenNV, NgaySinh,GioiTinh,MaCN) values
('NV006',N'Lê Tường An','12/9/1996',N'Nam','CN001')

insert into HoaDon(MaHD, MaKH_MBM, MaNV, NgayThangNam, HinhThucDongTienBH)
values ('HD001', 'KHM001', 'NV001', '1/1/2010', N'Năm')
insert into HoaDon(MaHD, MaKH_MBM, MaNV, NgayThangNam, HinhThucDongTienBH)
values ('HD002', 'KHM002', 'NV001', '2/1/2010', N'Năm')
insert into HoaDon(MaHD, MaKH_MBM, MaNV, NgayThangNam, HinhThucDongTienBH)
values ('HD003', 'KHM003', 'NV004', '3/1/2010', N'Năm')
insert into HoaDon(MaHD, MaKH_MBM, MaNV, NgayThangNam, HinhThucDongTienBH)
values ('HD004', 'KHM004', 'NV004', '4/1/2010', N'Năm')
select * from HoaDon

insert into ChiTietHoaDon(MaHD, MaSP, ThoiHanBH, ThoiHanDongTien, PhiTienBH, SoTienCanDong, TongTienBH)
values ('HD001', 'SP004', 10, 10, 1500000, NULL, NULL)
insert into ChiTietHoaDon(MaHD, MaSP, ThoiHanBH, ThoiHanDongTien, PhiTienBH, SoTienCanDong, TongTienBH)
values ('HD002', 'SP003', 15, 15, 1500000, NULL, NULL)
insert into ChiTietHoaDon(MaHD, MaSP, ThoiHanBH, ThoiHanDongTien, PhiTienBH, SoTienCanDong, TongTienBH)
values ('HD003', 'SP002', 15, 15, 1500000, NULL, NULL)
insert into ChiTietHoaDon(MaHD, MaSP, ThoiHanBH, ThoiHanDongTien, PhiTienBH, SoTienCanDong, TongTienBH)
values ('HD004', 'SP006', 10, 10, 1500000, NULL, NULL)
select * from ChiTietHoaDon