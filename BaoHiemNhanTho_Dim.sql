create database BaoHiemNhanTho_Dim
use BaoHiemNhanTho_Dim

create table Dim_SanPham
(
	MaSP char(10) primary key not null,
	TenSP nvarchar(50),
	DoTuoiThamGia nvarchar(20),
	MaLoaiBH char(10),
	GiaSP bigint,
)

create table Dim_ChiNhanh
(
    MaCN char(10) primary key not null,
	Tenchinhanh nvarchar(50),
	Khuvuc nvarchar(30),
	TinhTP nvarchar(30),
	Diachi nvarchar(100),
	SDT char(12),
)

create table Dim_Ngay
(
	NgayThangNam date primary key not null,
	Ngay int,
	Thang int,
	Nam int,
)

create table Dim_KH_MBM
(
	MaKH_MBM char(10) primary key  not null,
	TenKH_MBM nvarchar(50),
	Namsinh int,
	GioiTinh nvarchar(10),
	DiaChi nvarchar(100),
	CMND char(15),
	NgheNghiep nvarchar(50),
	DoiTuongDuocBaoHiem nvarchar(50),
)

create table BHNT_Fact
(
	NgayThangNam date not null,
	MaSP char(10) not null,
	MaKH_MBM char(10) not null,
	MaCN char(10) not null,
	HinhThucDongTienBH nvarchar(10) not null,
	ThoiHanBH int,
	ThoiHanDongTien int,
	PhiTienBH int,
	SoTienCanDong bigint,
	TongTienBH bigint,
	primary key (NgayThangNam, MaSP, MaKH_MBM, MaCN),
	constraint fk_fact_ngay foreign key(NgayThangNam) references Dim_Ngay(NgayThangNam),
	constraint fk_fact_sp foreign key (MaSP) references Dim_SanPham(MaSP),
	constraint fk_fact_kh_mbm foreign key (MaKH_MBM) references Dim_KH_MBM(MaKH_MBM),
	constraint fk_fact_cn foreign key (MaCN) references Dim_ChiNhanh(MaCN),
)

--Tạo hàm procudure để phát sinh các ngày tháng năm trong 1 năm
set dateformat dmy
declare @i int,
		@date datetime;

set @i = 1;
set @date = '20100101';

while @i <= 487
begin 
	insert into dbo.Dim_Ngay values (@date, DAY(@date), MONTH(@date), YEAR(@date));
	set @date = @date + 1;
	set @i = @i + 1;
end;

select * from Dim_Ngay
