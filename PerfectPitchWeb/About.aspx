<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PerfectPitchWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Baserad på chen et al. (2011) och Haraldsson et al. (2016).</h3>
    <p>Beräknar pitch for att minska threading, baserat främst på cheng et al.(2011), </p>
    <p>värden över 20 cm extrapoleras. Gantry rotationstid är ungefärlig, blir något snabbare vid t ex skalle.</p>
    <p> </p>
    <p>/André</p>
</asp:Content>
