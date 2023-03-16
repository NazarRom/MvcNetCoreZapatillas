using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcNetCoreZapatillas.Data;
using MvcNetCoreZapatillas.Models;

#region SQL SERVER
//VUESTRO PROCEDIMIENTO DE PAGINACION DE IMAGENES DE ZAPATILLAS

//create procedure sp_imagen_zapatillas
//(@idproducto int)
//AS
// select idimagen, idproducto, imagen from
//    (SELECT CAST(
//    ROW_NUMBER() OVER(ORDER BY idproducto) AS INT) AS POSICION,
//    ISNULL(IDIMAGEN, 0) AS IDIMAGEN, IDPRODUCTO, IMAGEN 
//    FROM IMAGENESZAPASPRACTICA
//	where idproducto = @idproducto) as query

//    where query.POSICION >= 1 and 1 < (1+2)
//GO
#endregion

namespace MvcNetCoreZapatillas.Repositories
{
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        public List<Zapatilla> GetZapatillas()
        {
            return this.context.Zapatillas.ToList();
        }

        public Zapatilla FindZapatilla(int idproducto)
        {
            return this.context.Zapatillas.FirstOrDefault(x => x.IdProducto == idproducto);
        }

        public List<ImagenZapatilla> FindImagenZapatilla(int idproducto)
        {
            string sql = "sp_imagen_zapatillas @idproducto";
            SqlParameter pamid = new SqlParameter("@idproducto", idproducto);
            var consulta = this.context.ImagenesZapatillas.FromSqlRaw(sql, pamid);
            List<ImagenZapatilla> imagens = consulta.ToList();
            return imagens;
        }

        public int GetNumeroDeImagenes(int idproducto)
        {
            var consulta = (from data in this.context.ImagenesZapatillas
                           where data.IdProducto == idproducto
                           select data).Count();
            return consulta;
        }

    }
}
