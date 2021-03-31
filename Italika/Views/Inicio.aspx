﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Italika.Views.Inicio" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catálogo Italikas</title>
</head>
<body>
    <h1>Evaluación: Branchbit - Italika        
    </h1>        
    <form id="form1" runat="server" style="padding-left:10%;padding-right:10%" visible="true">    
        <div style="position: relative;float:right;padding-bottom:20px">
            <asp:TextBox ID="tbBuscar" Enabled="true" runat="server">                                
            </asp:TextBox>
            <asp:Button ID="bBuscar" runat="server" Text="Buscar" OnClick="bBuscar_Click" />
            
        </div>                   
        <br />
    <div style="padding-top:20px;">                
        <center>
        <asp:GridView ID="gvItalikas" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvItalikas_SelectedIndexChanged"
            DataKeyNames="ID_ITALIKA" AllowPaging="false">
            <Columns>
                <asp:CommandField ShowSelectButton="true"/>
                <asp:BoundField DataField="ID_ITALIKA" HeaderText="NO." SortExpression="ID_ITALIKA" ReadOnly="True" />
                <asp:BoundField DataField="SKU" HeaderText="SKU" SortExpression="SKU" />
                <asp:BoundField DataField="FERT" HeaderText="FERT" SortExpression="FERT" />                
                <asp:BoundField DataField="MODELO" HeaderText="MODELO" SortExpression="MODELO" />                
                <asp:BoundField DataField="TIPO" HeaderText="TIPO" SortExpression="TIPO" />
                <asp:BoundField DataField="NUM_SERIE" HeaderText="NO. SERIE" SortExpression="NUM_SERIE" />
                <asp:BoundField DataField="FECHA" HeaderText="FECHA" SortExpression="FECHA" />
            </Columns>
        </asp:GridView>

        

        <h2 id="detalle" runat="server" visible="false">Detalle de Contacto</h2>
        <asp:DetailsView ID="dvItalikas" runat="server" AutoGenerateRows="False" Visible="False" DataKeyNames="ID_ITALIKA"
            AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" AutoGenerateInsertButton="false"
            OnModeChanging="dvItalikas_ModeChanging" OnModeChanged="dvItalikas_ModeChanged" OnItemDeleted="dvItalikas_ItemDeleted" OnItemDeleting="dvItalikas_ItemDeleting"
            OnItemInserted="dvItalikas_ItemInserted" OnItemInserting="dvItalikas_ItemInserting" OnItemUpdated="dvItalikas_ItemUpdated"
            OnItemUpdating="dvItalikas_ItemUpdating">
            <Fields>                
                <asp:BoundField DataField="ID_ITALIKA" HeaderText="ID_ITALIKA" SortExpression="ID_ITALIKA" ReadOnly="True" InsertVisible="false"/>
                <asp:BoundField DataField="SKU" HeaderText="SKU" SortExpression="SKU" />
                <asp:BoundField DataField="FERT" HeaderText="FERT" SortExpression="FERT" />                
                <asp:BoundField DataField="MODELO" HeaderText="MODELO" SortExpression="MODELO" />                
                <asp:BoundField DataField="TIPO" HeaderText="TIPO" SortExpression="TIPO" />
                <asp:BoundField DataField="NUM_SERIE" HeaderText="NO. SERIE" SortExpression="NUM_SERIE" />
                <asp:BoundField DataField="FECHA" HeaderText="FECHA" SortExpression="FECHA" />
            </Fields>
        </asp:DetailsView>
        </center>
    </div>
        <div style="position: relative;float:right;padding-top:20px">
            <asp:Button ID="bAgregar" runat="server" Text="Agregar Italika" OnClick="bAgregar_Click"/>
            <br />
        </div> 
    </form>
</body>
</html>