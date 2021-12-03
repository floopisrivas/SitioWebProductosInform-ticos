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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class articulo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7ArticuloId = (short)(NumberUtil.Val( GetPar( "ArticuloId"), "."));
               AssignAttri("", false, "AV7ArticuloId", StringUtil.LTrimStr( (decimal)(AV7ArticuloId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vARTICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ArticuloId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_4-151606", 0) ;
            }
            Form.Meta.addItem("description", "Articulo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtArticuloNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public articulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public articulo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ArticuloId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ArticuloId = aP1_ArticuloId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Articulo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "rounded", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "rounded", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "rounded", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "rounded", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "rounded", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtArticuloId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArticuloId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtArticuloId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ArticuloId), 4, 0, ".", "")), ((edtArticuloId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1ArticuloId), "ZZZ9")) : context.localUtil.Format( (decimal)(A1ArticuloId), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtArticuloId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtArticuloId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtArticuloNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArticuloNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtArticuloNombre_Internalname, A2ArticuloNombre, StringUtil.RTrim( context.localUtil.Format( A2ArticuloNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtArticuloNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtArticuloNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtArticuloStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArticuloStock_Internalname, "Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtArticuloStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A72ArticuloStock), 4, 0, ".", "")), ((edtArticuloStock_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A72ArticuloStock), "ZZZ9")) : context.localUtil.Format( (decimal)(A72ArticuloStock), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtArticuloStock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtArticuloStock_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A4Imagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000Imagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.PathToRelativeUrl( A4Imagen));
         GxWebStd.gx_bitmap( context, imgImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgImagen_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", "", "", 0, A4Imagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Articulo.htm");
         AssignProp("", false, imgImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.PathToRelativeUrl( A4Imagen)), true);
         AssignProp("", false, imgImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A4Imagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "rounded", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "rounded", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Articulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1ArticuloId = (short)(context.localUtil.CToN( cgiGet( "Z1ArticuloId"), ".", ","));
               Z2ArticuloNombre = cgiGet( "Z2ArticuloNombre");
               Z72ArticuloStock = (short)(context.localUtil.CToN( cgiGet( "Z72ArticuloStock"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7ArticuloId = (short)(context.localUtil.CToN( cgiGet( "vARTICULOID"), ".", ","));
               A40000Imagen_GXI = cgiGet( "IMAGEN_GXI");
               n40000Imagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000Imagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? true : false);
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1ArticuloId = (short)(context.localUtil.CToN( cgiGet( edtArticuloId_Internalname), ".", ","));
               AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
               A2ArticuloNombre = cgiGet( edtArticuloNombre_Internalname);
               AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtArticuloStock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtArticuloStock_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ARTICULOSTOCK");
                  AnyError = 1;
                  GX_FocusControl = edtArticuloStock_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A72ArticuloStock = 0;
                  AssignAttri("", false, "A72ArticuloStock", StringUtil.LTrimStr( (decimal)(A72ArticuloStock), 4, 0));
               }
               else
               {
                  A72ArticuloStock = (short)(context.localUtil.CToN( cgiGet( edtArticuloStock_Internalname), ".", ","));
                  AssignAttri("", false, "A72ArticuloStock", StringUtil.LTrimStr( (decimal)(A72ArticuloStock), 4, 0));
               }
               A4Imagen = cgiGet( imgImagen_Internalname);
               n4Imagen = false;
               AssignAttri("", false, "A4Imagen", A4Imagen);
               n4Imagen = (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgImagen_Internalname, ref  A4Imagen, ref  A40000Imagen_GXI);
               n40000Imagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000Imagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? true : false);
               n4Imagen = (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? true : false);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Articulo");
               A1ArticuloId = (short)(context.localUtil.CToN( cgiGet( edtArticuloId_Internalname), ".", ","));
               AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
               forbiddenHiddens.Add("ArticuloId", context.localUtil.Format( (decimal)(A1ArticuloId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1ArticuloId != Z1ArticuloId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("articulo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1ArticuloId = (short)(NumberUtil.Val( GetPar( "ArticuloId"), "."));
                  AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ARTICULOID");
                        AnyError = 1;
                        GX_FocusControl = edtArticuloId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes011( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "IgnitionPc");
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwarticulo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2ArticuloNombre = T00013_A2ArticuloNombre[0];
               Z72ArticuloStock = T00013_A72ArticuloStock[0];
            }
            else
            {
               Z2ArticuloNombre = A2ArticuloNombre;
               Z72ArticuloStock = A72ArticuloStock;
            }
         }
         if ( GX_JID == -3 )
         {
            Z1ArticuloId = A1ArticuloId;
            Z2ArticuloNombre = A2ArticuloNombre;
            Z72ArticuloStock = A72ArticuloStock;
            Z4Imagen = A4Imagen;
            Z40000Imagen_GXI = A40000Imagen_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         edtArticuloId_Enabled = 0;
         AssignProp("", false, edtArticuloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArticuloId_Enabled), 5, 0), true);
         edtArticuloId_Enabled = 0;
         AssignProp("", false, edtArticuloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArticuloId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ArticuloId) )
         {
            A1ArticuloId = AV7ArticuloId;
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2ArticuloNombre = T00014_A2ArticuloNombre[0];
            AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
            A72ArticuloStock = T00014_A72ArticuloStock[0];
            AssignAttri("", false, "A72ArticuloStock", StringUtil.LTrimStr( (decimal)(A72ArticuloStock), 4, 0));
            A40000Imagen_GXI = T00014_A40000Imagen_GXI[0];
            n40000Imagen_GXI = T00014_n40000Imagen_GXI[0];
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            A4Imagen = T00014_A4Imagen[0];
            n4Imagen = T00014_n4Imagen[0];
            AssignAttri("", false, "A4Imagen", A4Imagen);
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            ZM011( -3) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV11Pgmname = "Articulo";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Articulo";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 3) ;
            RcdFound1 = 1;
            A1ArticuloId = T00013_A1ArticuloId[0];
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
            A2ArticuloNombre = T00013_A2ArticuloNombre[0];
            AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
            A72ArticuloStock = T00013_A72ArticuloStock[0];
            AssignAttri("", false, "A72ArticuloStock", StringUtil.LTrimStr( (decimal)(A72ArticuloStock), 4, 0));
            A40000Imagen_GXI = T00013_A40000Imagen_GXI[0];
            n40000Imagen_GXI = T00013_n40000Imagen_GXI[0];
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            A4Imagen = T00013_A4Imagen[0];
            n4Imagen = T00013_n4Imagen[0];
            AssignAttri("", false, "A4Imagen", A4Imagen);
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            Z1ArticuloId = A1ArticuloId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1ArticuloId[0] < A1ArticuloId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1ArticuloId[0] > A1ArticuloId ) ) )
            {
               A1ArticuloId = T00016_A1ArticuloId[0];
               AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1ArticuloId[0] > A1ArticuloId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1ArticuloId[0] < A1ArticuloId ) ) )
            {
               A1ArticuloId = T00017_A1ArticuloId[0];
               AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtArticuloNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1ArticuloId != Z1ArticuloId )
               {
                  A1ArticuloId = Z1ArticuloId;
                  AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ARTICULOID");
                  AnyError = 1;
                  GX_FocusControl = edtArticuloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtArticuloNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtArticuloNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1ArticuloId != Z1ArticuloId )
               {
                  /* Insert record */
                  GX_FocusControl = edtArticuloNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ARTICULOID");
                     AnyError = 1;
                     GX_FocusControl = edtArticuloId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtArticuloNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A1ArticuloId != Z1ArticuloId )
         {
            A1ArticuloId = Z1ArticuloId;
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ARTICULOID");
            AnyError = 1;
            GX_FocusControl = edtArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtArticuloNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1ArticuloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Articulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2ArticuloNombre, T00012_A2ArticuloNombre[0]) != 0 ) || ( Z72ArticuloStock != T00012_A72ArticuloStock[0] ) )
            {
               if ( StringUtil.StrCmp(Z2ArticuloNombre, T00012_A2ArticuloNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("articulo:[seudo value changed for attri]"+"ArticuloNombre");
                  GXUtil.WriteLogRaw("Old: ",Z2ArticuloNombre);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2ArticuloNombre[0]);
               }
               if ( Z72ArticuloStock != T00012_A72ArticuloStock[0] )
               {
                  GXUtil.WriteLog("articulo:[seudo value changed for attri]"+"ArticuloStock");
                  GXUtil.WriteLogRaw("Old: ",Z72ArticuloStock);
                  GXUtil.WriteLogRaw("Current: ",T00012_A72ArticuloStock[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Articulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {A2ArticuloNombre, A72ArticuloStock, n4Imagen, A4Imagen, n40000Imagen_GXI, A40000Imagen_GXI});
                     A1ArticuloId = T00018_A1ArticuloId[0];
                     AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Articulo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {A2ArticuloNombre, A72ArticuloStock, A1ArticuloId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Articulo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Articulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000110 */
            pr_default.execute(8, new Object[] {n4Imagen, A4Imagen, n40000Imagen_GXI, A40000Imagen_GXI, A1ArticuloId});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("Articulo");
         }
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000111 */
                  pr_default.execute(9, new Object[] {A1ArticuloId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("Articulo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Articulo";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000112 */
            pr_default.execute(10, new Object[] {A1ArticuloId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000113 */
            pr_default.execute(11, new Object[] {A1ArticuloId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista Precio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("articulo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("articulo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000114 */
         pr_default.execute(12);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1ArticuloId = T000114_A1ArticuloId[0];
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1ArticuloId = T000114_A1ArticuloId[0];
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtArticuloId_Enabled = 0;
         AssignProp("", false, edtArticuloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArticuloId_Enabled), 5, 0), true);
         edtArticuloNombre_Enabled = 0;
         AssignProp("", false, edtArticuloNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArticuloNombre_Enabled), 5, 0), true);
         edtArticuloStock_Enabled = 0;
         AssignProp("", false, edtArticuloStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArticuloStock_Enabled), 5, 0), true);
         imgImagen_Enabled = 0;
         AssignProp("", false, imgImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImagen_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 348140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20211152252537", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("articulo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ArticuloId,4,0))}, new string[] {"Gx_mode","ArticuloId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Articulo");
         forbiddenHiddens.Add("ArticuloId", context.localUtil.Format( (decimal)(A1ArticuloId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("articulo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1ArticuloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ArticuloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2ArticuloNombre", Z2ArticuloNombre);
         GxWebStd.gx_hidden_field( context, "Z72ArticuloStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72ArticuloStock), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vARTICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ArticuloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vARTICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ArticuloId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "IMAGEN_GXI", A40000Imagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
         GXCCtlgxBlob = "IMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A4Imagen);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("articulo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ArticuloId,4,0))}, new string[] {"Gx_mode","ArticuloId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Articulo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Articulo" ;
      }

      protected void InitializeNonKey011( )
      {
         A2ArticuloNombre = "";
         AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
         A72ArticuloStock = 0;
         AssignAttri("", false, "A72ArticuloStock", StringUtil.LTrimStr( (decimal)(A72ArticuloStock), 4, 0));
         A4Imagen = "";
         n4Imagen = false;
         AssignAttri("", false, "A4Imagen", A4Imagen);
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         n4Imagen = (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? true : false);
         A40000Imagen_GXI = "";
         n40000Imagen_GXI = false;
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         Z2ArticuloNombre = "";
         Z72ArticuloStock = 0;
      }

      protected void InitAll011( )
      {
         A1ArticuloId = 0;
         AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202111522525314", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("articulo.js", "?202111522525314", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtArticuloId_Internalname = "ARTICULOID";
         edtArticuloNombre_Internalname = "ARTICULONOMBRE";
         edtArticuloStock_Internalname = "ARTICULOSTOCK";
         imgImagen_Internalname = "IMAGEN";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Articulo";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgImagen_Enabled = 1;
         edtArticuloStock_Jsonclick = "";
         edtArticuloStock_Enabled = 1;
         edtArticuloNombre_Jsonclick = "";
         edtArticuloNombre_Enabled = 1;
         edtArticuloId_Jsonclick = "";
         edtArticuloId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ArticuloId',fld:'vARTICULOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ArticuloId',fld:'vARTICULOID',pic:'ZZZ9',hsh:true},{av:'A1ArticuloId',fld:'ARTICULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ARTICULOID","{handler:'Valid_Articuloid',iparms:[]");
         setEventMetadata("VALID_ARTICULOID",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2ArticuloNombre = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2ArticuloNombre = "";
         A4Imagen = "";
         A40000Imagen_GXI = "";
         sImgUrl = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z4Imagen = "";
         Z40000Imagen_GXI = "";
         T00014_A1ArticuloId = new short[1] ;
         T00014_A2ArticuloNombre = new string[] {""} ;
         T00014_A72ArticuloStock = new short[1] ;
         T00014_A40000Imagen_GXI = new string[] {""} ;
         T00014_n40000Imagen_GXI = new bool[] {false} ;
         T00014_A4Imagen = new string[] {""} ;
         T00014_n4Imagen = new bool[] {false} ;
         T00015_A1ArticuloId = new short[1] ;
         T00013_A1ArticuloId = new short[1] ;
         T00013_A2ArticuloNombre = new string[] {""} ;
         T00013_A72ArticuloStock = new short[1] ;
         T00013_A40000Imagen_GXI = new string[] {""} ;
         T00013_n40000Imagen_GXI = new bool[] {false} ;
         T00013_A4Imagen = new string[] {""} ;
         T00013_n4Imagen = new bool[] {false} ;
         T00016_A1ArticuloId = new short[1] ;
         T00017_A1ArticuloId = new short[1] ;
         T00012_A1ArticuloId = new short[1] ;
         T00012_A2ArticuloNombre = new string[] {""} ;
         T00012_A72ArticuloStock = new short[1] ;
         T00012_A40000Imagen_GXI = new string[] {""} ;
         T00012_n40000Imagen_GXI = new bool[] {false} ;
         T00012_A4Imagen = new string[] {""} ;
         T00012_n4Imagen = new bool[] {false} ;
         T00018_A1ArticuloId = new short[1] ;
         T000112_A33FacturaId = new short[1] ;
         T000112_A1ArticuloId = new short[1] ;
         T000113_A1ArticuloId = new short[1] ;
         T000113_A62ListaFecha = new DateTime[] {DateTime.MinValue} ;
         T000114_A1ArticuloId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.articulo__default(),
            new Object[][] {
                new Object[] {
               T00012_A1ArticuloId, T00012_A2ArticuloNombre, T00012_A72ArticuloStock, T00012_A40000Imagen_GXI, T00012_n40000Imagen_GXI, T00012_A4Imagen, T00012_n4Imagen
               }
               , new Object[] {
               T00013_A1ArticuloId, T00013_A2ArticuloNombre, T00013_A72ArticuloStock, T00013_A40000Imagen_GXI, T00013_n40000Imagen_GXI, T00013_A4Imagen, T00013_n4Imagen
               }
               , new Object[] {
               T00014_A1ArticuloId, T00014_A2ArticuloNombre, T00014_A72ArticuloStock, T00014_A40000Imagen_GXI, T00014_n40000Imagen_GXI, T00014_A4Imagen, T00014_n4Imagen
               }
               , new Object[] {
               T00015_A1ArticuloId
               }
               , new Object[] {
               T00016_A1ArticuloId
               }
               , new Object[] {
               T00017_A1ArticuloId
               }
               , new Object[] {
               T00018_A1ArticuloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000112_A33FacturaId, T000112_A1ArticuloId
               }
               , new Object[] {
               T000113_A1ArticuloId, T000113_A62ListaFecha
               }
               , new Object[] {
               T000114_A1ArticuloId
               }
            }
         );
         AV11Pgmname = "Articulo";
      }

      private short wcpOAV7ArticuloId ;
      private short Z1ArticuloId ;
      private short Z72ArticuloStock ;
      private short GxWebError ;
      private short AV7ArticuloId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1ArticuloId ;
      private short A72ArticuloStock ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtArticuloId_Enabled ;
      private int edtArticuloNombre_Enabled ;
      private int edtArticuloStock_Enabled ;
      private int imgImagen_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtArticuloNombre_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtArticuloId_Internalname ;
      private string edtArticuloId_Jsonclick ;
      private string edtArticuloNombre_Jsonclick ;
      private string edtArticuloStock_Internalname ;
      private string edtArticuloStock_Jsonclick ;
      private string imgImagen_Internalname ;
      private string sImgUrl ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A4Imagen_IsBlob ;
      private bool n40000Imagen_GXI ;
      private bool n4Imagen ;
      private bool returnInSub ;
      private string Z2ArticuloNombre ;
      private string A2ArticuloNombre ;
      private string A40000Imagen_GXI ;
      private string Z40000Imagen_GXI ;
      private string A4Imagen ;
      private string Z4Imagen ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00014_A1ArticuloId ;
      private string[] T00014_A2ArticuloNombre ;
      private short[] T00014_A72ArticuloStock ;
      private string[] T00014_A40000Imagen_GXI ;
      private bool[] T00014_n40000Imagen_GXI ;
      private string[] T00014_A4Imagen ;
      private bool[] T00014_n4Imagen ;
      private short[] T00015_A1ArticuloId ;
      private short[] T00013_A1ArticuloId ;
      private string[] T00013_A2ArticuloNombre ;
      private short[] T00013_A72ArticuloStock ;
      private string[] T00013_A40000Imagen_GXI ;
      private bool[] T00013_n40000Imagen_GXI ;
      private string[] T00013_A4Imagen ;
      private bool[] T00013_n4Imagen ;
      private short[] T00016_A1ArticuloId ;
      private short[] T00017_A1ArticuloId ;
      private short[] T00012_A1ArticuloId ;
      private string[] T00012_A2ArticuloNombre ;
      private short[] T00012_A72ArticuloStock ;
      private string[] T00012_A40000Imagen_GXI ;
      private bool[] T00012_n40000Imagen_GXI ;
      private string[] T00012_A4Imagen ;
      private bool[] T00012_n4Imagen ;
      private short[] T00018_A1ArticuloId ;
      private short[] T000112_A33FacturaId ;
      private short[] T000112_A1ArticuloId ;
      private short[] T000113_A1ArticuloId ;
      private DateTime[] T000113_A62ListaFecha ;
      private short[] T000114_A1ArticuloId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class articulo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@ArticuloNombre",GXType.NVarChar,40,0) ,
          new ParDef("@ArticuloStock",GXType.Int16,4,0) ,
          new ParDef("@Imagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
          new ParDef("@Imagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="Articulo", Fld="Imagen"}
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@ArticuloNombre",GXType.NVarChar,40,0) ,
          new ParDef("@ArticuloStock",GXType.Int16,4,0) ,
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@Imagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
          new ParDef("@Imagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Articulo", Fld="Imagen"} ,
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [ArticuloId], [ArticuloNombre], [ArticuloStock], [Imagen_GXI], [Imagen] FROM [Articulo] WITH (UPDLOCK) WHERE [ArticuloId] = @ArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [ArticuloId], [ArticuloNombre], [ArticuloStock], [Imagen_GXI], [Imagen] FROM [Articulo] WHERE [ArticuloId] = @ArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT TM1.[ArticuloId], TM1.[ArticuloNombre], TM1.[ArticuloStock], TM1.[Imagen_GXI], TM1.[Imagen] FROM [Articulo] TM1 WHERE TM1.[ArticuloId] = @ArticuloId ORDER BY TM1.[ArticuloId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [ArticuloId] FROM [Articulo] WHERE [ArticuloId] = @ArticuloId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TOP 1 [ArticuloId] FROM [Articulo] WHERE ( [ArticuloId] > @ArticuloId) ORDER BY [ArticuloId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00017", "SELECT TOP 1 [ArticuloId] FROM [Articulo] WHERE ( [ArticuloId] < @ArticuloId) ORDER BY [ArticuloId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00018", "INSERT INTO [Articulo]([ArticuloNombre], [ArticuloStock], [Imagen], [Imagen_GXI]) VALUES(@ArticuloNombre, @ArticuloStock, @Imagen, @Imagen_GXI); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT00018)
             ,new CursorDef("T00019", "UPDATE [Articulo] SET [ArticuloNombre]=@ArticuloNombre, [ArticuloStock]=@ArticuloStock  WHERE [ArticuloId] = @ArticuloId", GxErrorMask.GX_NOMASK,prmT00019)
             ,new CursorDef("T000110", "UPDATE [Articulo] SET [Imagen]=@Imagen, [Imagen_GXI]=@Imagen_GXI  WHERE [ArticuloId] = @ArticuloId", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "DELETE FROM [Articulo]  WHERE [ArticuloId] = @ArticuloId", GxErrorMask.GX_NOMASK,prmT000111)
             ,new CursorDef("T000112", "SELECT TOP 1 [FacturaId], [ArticuloId] FROM [FacturaDetalle] WHERE [ArticuloId] = @ArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000113", "SELECT TOP 1 [ArticuloId], [ListaFecha] FROM [ListaPrecio] WHERE [ArticuloId] = @ArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000114", "SELECT [ArticuloId] FROM [Articulo] ORDER BY [ArticuloId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
