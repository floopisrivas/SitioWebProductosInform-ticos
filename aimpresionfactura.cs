using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aimpresionfactura : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "FacturaId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8FacturaId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aimpresionfactura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aimpresionfactura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( short aP0_FacturaId )
      {
         this.AV8FacturaId = aP0_FacturaId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_FacturaId )
      {
         aimpresionfactura objaimpresionfactura;
         objaimpresionfactura = new aimpresionfactura();
         objaimpresionfactura.AV8FacturaId = aP0_FacturaId;
         objaimpresionfactura.context.SetSubmitInitialConfig(context);
         objaimpresionfactura.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaimpresionfactura);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aimpresionfactura)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            /* Using cursor P000F3 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1ArticuloId = P000F3_A1ArticuloId[0];
               A33FacturaId = P000F3_A33FacturaId[0];
               A34FechaFactura = P000F3_A34FechaFactura[0];
               A2ArticuloNombre = P000F3_A2ArticuloNombre[0];
               A71FacturaTotIva = P000F3_A71FacturaTotIva[0];
               A52FacturaSubtotal = P000F3_A52FacturaSubtotal[0];
               A78PrecioArticuloVenta = P000F3_A78PrecioArticuloVenta[0];
               A66FacturaCantidad = P000F3_A66FacturaCantidad[0];
               A2ArticuloNombre = P000F3_A2ArticuloNombre[0];
               A34FechaFactura = P000F3_A34FechaFactura[0];
               A71FacturaTotIva = P000F3_A71FacturaTotIva[0];
               A52FacturaSubtotal = P000F3_A52FacturaSubtotal[0];
               A68FacturaVIva = (decimal)((A66FacturaCantidad*A78PrecioArticuloVenta)*21/ (decimal)(100));
               A51FacturaTotal = (decimal)(A52FacturaSubtotal+A71FacturaTotIva);
               H0F0( false, 207) ;
               getPrinter().GxDrawLine(17, Gx_line+183, 825, Gx_line+183, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Arial Black", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("FACTURA B", 433, Gx_line+0, 591, Gx_line+33, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 13, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N°", 358, Gx_line+50, 391, Gx_line+83, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A33FacturaId), "ZZZ9")), 450, Gx_line+50, 583, Gx_line+72, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A34FechaFactura, "99/99/99"), 442, Gx_line+83, 550, Gx_line+105, 2, 0, 0, 0) ;
               getPrinter().GxDrawText("CUIT", 342, Gx_line+117, 384, Gx_line+138, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("000-11111-0000", 442, Gx_line+117, 600, Gx_line+134, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 342, Gx_line+83, 394, Gx_line+104, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("INICIO ACTIVIDADES", 317, Gx_line+150, 487, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Junio-2019", 517, Gx_line+150, 625, Gx_line+171, 0, 0, 0, 0) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "9b4980b7-fa0d-4aae-aa21-0ee4c5a23ee2", "", context.GetTheme( )), 58, Gx_line+17, 266, Gx_line+167) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+207);
               H0F0( false, 56) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 17, Gx_line+17, 70, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 133, Gx_line+17, 201, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripcion", 358, Gx_line+17, 458, Gx_line+38, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("IVA", 625, Gx_line+17, 654, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unitario", 700, Gx_line+17, 758, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(8, Gx_line+50, 816, Gx_line+50, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+56);
               H0F0( false, 86) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A33FacturaId), "ZZZ9")), 17, Gx_line+17, 92, Gx_line+50, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+83, 933, Gx_line+83, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A68FacturaVIva, "ZZZZ9.99")), 575, Gx_line+17, 675, Gx_line+67, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A52FacturaSubtotal, "ZZZZ9.99")), 700, Gx_line+17, 775, Gx_line+50, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A66FacturaCantidad, "ZZZZ9.99")), 142, Gx_line+17, 200, Gx_line+48, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2ArticuloNombre, "")), 300, Gx_line+17, 509, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+86);
               H0F0( false, 83) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 13, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Subtotal", 583, Gx_line+17, 648, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total", 592, Gx_line+50, 639, Gx_line+76, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A51FacturaTotal, "ZZZZ9.99")), 717, Gx_line+50, 775, Gx_line+83, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A51FacturaTotal, "ZZZZ9.99")), 717, Gx_line+17, 775, Gx_line+50, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+83);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException e )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException e )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0F0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Arial Black", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000F3_A1ArticuloId = new short[1] ;
         P000F3_A33FacturaId = new short[1] ;
         P000F3_A34FechaFactura = new DateTime[] {DateTime.MinValue} ;
         P000F3_A2ArticuloNombre = new string[] {""} ;
         P000F3_A71FacturaTotIva = new decimal[1] ;
         P000F3_A52FacturaSubtotal = new decimal[1] ;
         P000F3_A78PrecioArticuloVenta = new decimal[1] ;
         P000F3_A66FacturaCantidad = new decimal[1] ;
         A34FechaFactura = DateTime.MinValue;
         A2ArticuloNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aimpresionfactura__default(),
            new Object[][] {
                new Object[] {
               P000F3_A1ArticuloId, P000F3_A33FacturaId, P000F3_A34FechaFactura, P000F3_A2ArticuloNombre, P000F3_A71FacturaTotIva, P000F3_A52FacturaSubtotal, P000F3_A78PrecioArticuloVenta, P000F3_A66FacturaCantidad
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8FacturaId ;
      private short GxWebError ;
      private short A1ArticuloId ;
      private short A33FacturaId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A71FacturaTotIva ;
      private decimal A52FacturaSubtotal ;
      private decimal A78PrecioArticuloVenta ;
      private decimal A66FacturaCantidad ;
      private decimal A68FacturaVIva ;
      private decimal A51FacturaTotal ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime A34FechaFactura ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A2ArticuloNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000F3_A1ArticuloId ;
      private short[] P000F3_A33FacturaId ;
      private DateTime[] P000F3_A34FechaFactura ;
      private string[] P000F3_A2ArticuloNombre ;
      private decimal[] P000F3_A71FacturaTotIva ;
      private decimal[] P000F3_A52FacturaSubtotal ;
      private decimal[] P000F3_A78PrecioArticuloVenta ;
      private decimal[] P000F3_A66FacturaCantidad ;
   }

   public class aimpresionfactura__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000F3", "SELECT T1.[ArticuloId], T1.[FacturaId], T3.[FechaFactura], T2.[ArticuloNombre], COALESCE( T4.[FacturaTotIva], 0) AS FacturaTotIva, COALESCE( T4.[FacturaSubtotal], 0) AS FacturaSubtotal, T1.[PrecioArticuloVenta], T1.[FacturaCantidad] FROM ((([FacturaDetalle] T1 INNER JOIN [Articulo] T2 ON T2.[ArticuloId] = T1.[ArticuloId]) INNER JOIN [Factura] T3 ON T3.[FacturaId] = T1.[FacturaId]) LEFT JOIN (SELECT SUM([FacturaCantidad] * CAST([PrecioArticuloVenta] AS decimal( 18, 10))) AS FacturaSubtotal, [FacturaId], SUM(( [FacturaCantidad] * CAST([PrecioArticuloVenta] AS decimal( 18, 10))) * CAST(CAST(21 AS decimal( 13, 10)) / 100 AS decimal( 24, 10))) AS FacturaTotIva FROM [FacturaDetalle] GROUP BY [FacturaId] ) T4 ON T4.[FacturaId] = T1.[FacturaId]) WHERE T1.[FacturaId] = 1 ORDER BY T1.[FacturaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

}
