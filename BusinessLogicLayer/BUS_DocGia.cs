﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using DatabaseAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BUS_DocGia
    {
        DAL_DocGia dalDocGia = new DAL_DocGia();

        public DataTable getDocGia()
        {
            return dalDocGia.Get();
        }

        public bool insertDocGia(string prvMaDocGia, string hoTen, string diaChi, string soDT, string cmnd, DateTime ngaySinh, DateTime ngayDK)
        {
            try
            {
                int indexOfString = 2;
                for(int i = 2; i < prvMaDocGia.Length; i++)
                {
                    if(prvMaDocGia[i] != '0')
                    {
                        indexOfString = i;
                    }
                }

                int iMaDocGia = int.Parse(prvMaDocGia.Substring(indexOfString)) + 1;
                string sMaDocGia = "DG";
                if (iMaDocGia >= 0 && iMaDocGia <= 9)
                {
                    sMaDocGia += string.Format("00{0}", iMaDocGia.ToString());
                }
                else if (iMaDocGia >= 10 && iMaDocGia <= 99)
                {
                    sMaDocGia += string.Format("0{0}", iMaDocGia.ToString());
                }
                else if (iMaDocGia >= 100 && iMaDocGia <= 999)
                {
                    sMaDocGia += iMaDocGia.ToString();
                }


                DTO_DocGia dTO_DocGia = new DTO_DocGia(sMaDocGia, hoTen, diaChi, soDT, cmnd, ngaySinh, ngayDK);
                
                return dalDocGia.Insert(dTO_DocGia);
            }
            catch
            {
                return false;
            }
        }
        public bool updateDocGia(DTO_DocGia dTO_DocGia)
        {
            return dalDocGia.Update(dTO_DocGia);
        }
        public bool delete(string MaDocGia)
        {
            return dalDocGia.Delete(MaDocGia);
        }
        public DataTable getDocGia(string MaDocGia)
        {
            return dalDocGia.Get(MaDocGia);
        }
    }
}
