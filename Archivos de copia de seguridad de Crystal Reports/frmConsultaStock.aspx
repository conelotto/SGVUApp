<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmConsultaStock.aspx.vb" Inherits="SGCVU.frmConsultaStock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Consulta de stock</title>
    <link href="../Static/css/jquery.mobile-1.4.5.min.css" rel="stylesheet" type="text/css" />

    <script src="../Static/js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.mobile-1.4.5.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="Scripts/frmConsultaStock.js" type="text/javascript"></script>

    <style>
        /* Header */
        .jqm-custom 
        {
           background-color: #fff;
        }
        .jqm-custom .jqm-header {
	        border-top: 4px solid #FEC200;
	        background-color: #1D1D1D;
	        color: #fff;
	        font-family: Verdana;
        }
        .jqm-custom .jqm-header h2 {
	        padding: .4em 0 .1em;
	        margin: 0 3em;
	        text-align: left;
	        margin-left: 0px;
	        margin-right: 0px;
        }
        .jqm-custom .jqm-header h2 a {
	        display: inline-block;
	        text-decoration: none;
	        min-height: 40px;
        }
        .jqm-custom .jqm-header h2 img {
	        display: block;
	        width: 140px;
	        height: auto;
        }
        .jqm-custom .jqm-header h2 > img {
	        display: inline-block;
        }
        .jqm-custom .jqm-header p {
	        position: absolute;
	        margin: 0;
	        bottom: auto;
		    left: auto;
		    top: 40%;
		    right: 1%;
		    font-weight: 100;
        }
        /* Content */
        .jqm-custom .jqm-content {
	        padding-top: 1em;
        }
        .jqm-custom .jqm-content .ui-btn {
            background-color: #ffffff;
	        border-style: solid;
	        border-width: 1px;
	        border-color: #999999;
	        color: #000000;
	        font-family: Tahoma;
	        font-size: 11px;
	        font-weight: normal;
	        padding-bottom: 5px;
	        text-transform: uppercase;
	        text-decoration: none;
        }
        .jqm-custom .jqm-content .ui-btn:hover {
	        background-color: #FFD553;
	        border:1px solid #D2A300;
	        color: #000000;
        }
        .jqm-custom .jqm-content .icon-preload, icon-preload:hover {
            display:inline-block;
            background-repeat:no-repeat;
            margin-right:5px;
            margin-left:0;
            height:18px;
            width:18px;
            vertical-align:text-bottom;
            background-position:0 0;
            background-image:url('../Images/loading-consulta.gif')
        }
        .jqm-custom .jqm-content .msj-preload {
           margin-bottom:20px;
           margin-top: 20px;
           text-align:center;
        }
        .jqm-custom .jqm-content .link-inventario {
           margin-bottom:10px;
           text-align: right;
        }
        .jqm-custom .jqm-content .jqm-busqueda {
           margin-bottom:10px;
           border-color: #FEC200;
        }
        .jqm-custom .jqm-content .jqm-resultado {
           margin-top:10px;
           border-color: #FEC200;
        }
        /* Footer */
        .jqm-custom .jqm-footer 
        {
            border-bottom: 4px solid #FEC200;
	        background-color: #1D1D1D;
	        color: #fff;
	        font-family: Verdana;
	        font-weight: 100;
	        font-size:12px;
	        text-align:center;
	        padding-top: 5px;
	        padding-bottom: 5px;
        }
        
        .estado
        {
           font-size:1em;
        }
        
        /* Validación */
        label.error
        {
           color:#933;
           font-style:italic;
        }
        input.error
        {
           border:1px solid #933;
           background-color:#f3e0e0;
           color:#933;
        }
        /* Mensajes */
        .alert
        {
           -webkit-box-sizing:border-box;
           -moz-box-sizing:border-box;
           box-sizing:border-box;
           position:relative;
           width:100%;
           margin:0 auto 20px;
           padding:8px 35px 8px 44px;
           border-radius:0;
           border:solid 1px;
        }
        .alert>i
        {
           position:absolute;
           top:9px;
           left:8px;
           background-image:url('../Images/icons-sprite-msg.png');
           background-repeat:no-repeat;
           margin-right:5px;
           height:16px;
           width:16px;
        }
        .alert.alert-info
        {
           background:#dfecf7;
           border-color:#cae7f1;
           color:#5b85ad;
        }
        .alert.alert-info i,.alert.alert-info i:hover
        {
           background-position:0 0;
        }
    </style>
</head>
<body>
    <div id="home" data-role="page" class="jqm-custom">
        <div data-role="header" class="jqm-header">
            <h2><a href="#"><img src="../Images/Logo-Ferreyros-mobile.png"></a></h2>
            <p>Consulta Stock</p>
        </div>

        <div role="main" class="ui-content jqm-content">
            <div class="link-inventario"><a href="frmWorkflow_ReservaUnidades.aspx" data-ajax="false">Inventario</a></div>
            <div class="ui-body ui-body-a ui-corner-all jqm-busqueda">
                <form id="frmBusqueda">
                    <div class="ui-field-contain">
                        <label for="txtModelo">Modelo Genérico:</label>
                        <input type="text" name="txtModelo" id="txtModelo">
                    </div>
                    <a href="#" class="ui-btn" id="btnBuscar"><img src="../Images/btnSearch.png" align="right" />Buscar</a>
                    <div class="ui-field-contain" id="modRelacionados">
                        <label>Modelos relacionados:</label>
                        <label id="lblModelosRelacionados"></label>
                    </div>
                </form>
            </div>
            <div id="msgBusqueda" class="msj-preload msj-preload-20">
                <i class="icon-preload"></i>Buscando registros, espere un momento por favor...
            </div>
            <div class="alert alert-info" id="msgNoResultados"><i></i> No se encontraron registros.</div>
            <div id="resultadoBusqueda" class="ui-body ui-body-a ui-corner-all jqm-resultado">
                <table style="width: 100%;" class="ui-responsive">
                    <thead>
                        <tr>
                            <td style="width: 50%;"><b>En Perú</b></td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="estado">● Libre</td>
                            <td>0</td>
                        </tr>
                        <tr>
                            <td class="estado">● Reservado</td>
                            <td>0</td>
                        </tr>
                        <tr>
                            <td><b>Total</b></td>
                            <td>0</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <table style="width: 100%;" class="ui-responsive">
                    <thead>
                        <tr>
                            <td style="width: 35%;"><b>Tránsito</b></td>
                            <td style="width: 15%;"><b>Mes</b></td>
                            <td><b>J</b></td>
                            <td><b>A</b></td>
                            <td><b>S</b></td>
                            <td><b>O</b></td>
                            <td><b>N</b></td>
                            <td><b>D</b></td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="estado">● Libre</td>
                            <td></td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                        </tr>
                        <tr>
                            <td class="estado">● Reservado</td>
                            <td></td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                        </tr>
                        <tr>
                            <td><b>Total</b></td>
                            <td></td>
                            <td><b>0</b></td>
                            <td><b>0</b></td>
                            <td><b>0</b></td>
                            <td><b>0</b></td>
                            <td><b>0</b></td>
                            <td><b>0</b></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <div data-role="footer" data-position="fixed" class="jqm-footer">
            <span>Copyright © Ferreycorp 2015</span>
        </div>
    </div>
</body>
</html>