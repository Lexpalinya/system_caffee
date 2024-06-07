using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeshopCsharp.modle
{
    public class Product
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public string PType { get; set; }
        public string PSize { get; set; }
        public string PPrice { get; set; }
        public int PAmount { get; set; }
        public int PStatus { get; set; }
        public int PPriceOriginal { get; set; }
        public string PExp { get; set; }
        public byte[] PImage { get; set; }

    }





    public class ProductRepository
    {

        public readonly IDbConnection dbConnection;
        public ProductRepository(IDbConnection connection)
        {
            dbConnection = connection ?? throw new AggregateException(nameof(connection));

        }


        // Get All Products ----------------------------------------------------------------------
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return dbConnection.Query<Product>("SELECT * FROM tb_products");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<Product>();
            }
        }
        // Get Products By Type -----------------------------------------------------------------------
        public IEnumerable<Product> GetProductByType(Product product)
        {
            try
            {

                return dbConnection.Query<Product>("SELECT * FROM tb_products WHERE pType=@pType", product);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<Product>();
            }
        }

        // Get Products By Status -------------------------------------------------------------------------
        public IEnumerable<Product> GetProductByStatus()
        {
            try
            {
                return dbConnection.Query<Product>("SELECT * FROM tb_products WHERE pStatus=@pStatus", new { pStatus = 1 });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error); return Enumerable.Empty<Product>(); }
        }
        public IEnumerable<Product> GetProductByStatusAmount()
        {
            try
            {
                return dbConnection.Query<Product>("SELECT pAmount FROM tb_products WHERE pStatus=@pStatus", new { pStatus = 1 });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error); return Enumerable.Empty<Product>(); }


        }

        // Add Product --------------------------------------------------------------------------------------
        public void AddProduct(Product product)
        {
            try
            {
                string sql = "INSERT INTO tb_products (pName, pType, pSize, pAmount,pImage, pStatus, pPriceOriginal, pExp,pPrice) " +
                      "VALUES (@PName, @PType, @PSize,@PAmount, @PImage, @PStatus, @PPriceOriginal, @PExp,@PPrice)";
                int rowAffected = dbConnection.Execute(sql, product);
                if (rowAffected == 1)
                {
                    MessageBox.Show("ບັນທຶກສຳເລັດ", "Save", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ຂະໜາດຂອງຮູບໃຫ່ຍເກີນໄປ" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update Product ---------------------------------------------------------------------------------------
        public void UpdateProduct(Product product)
        {
            try
            {
                string sql = "UPDATE tb_products SET pName=@pName,pType=@pType,pSize=@pSize,pAmount=@PAmount,pImage=@pImage,pStatus=@pStatus,pPriceOriginal=@pPriceOriginal,pExp=@pExp,pPrice=@pPrice WHERE pId=@pID";
                int rowAffected = dbConnection.Execute(sql, product);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ຂະໜາດຂອງຮູບໃຫ່ຍເກີນໄປ" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateAmount(Product product)
        {
            try
            {
                string sql = "UPDATE tb_products SET pAmount=pAmount-@Amount WHERE pId=@pID";
                int rowAffected = dbConnection.Execute(sql, new { Amount = product.PAmount, pID = product.PId });
                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   // MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Update Product Status and Amount ---------------------------------------------------------------------------------

        public void UpdateStatus()
        {
            try
            {
                string sql = "UPDATE tb_products SET pStatus = 0 WHERE pAmount=0";
                int rowAffected = dbConnection.Execute(sql);

                if (rowAffected == 0)
                {
                    MessageBox.Show("ການແກ້ໄຂຜິດພາດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                 //   MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void UpdateStatusAndAmount(Product product)
        {
            try
            {
                string sql = "UPDATE tb_products SET pAmount=@PAmount,pStatus=@pStatus WHERE pId=@pID";
                int rowAffected = dbConnection.Execute(sql, product);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        // Delete Product ----------------------------------------------------------------------------------------
        public void DeteleProduct(Product product)
        {
            try
            {
                string sql = "DELETE FROM tb_products WHERE pId=@pId";
                int rowAffected = dbConnection.Execute(sql, product);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ລົບຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ລົບສຳເລັດ", "DELETE", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ບໍໍ່ມີໃນລະບົບ" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }















    }


}
