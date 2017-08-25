<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PerfectPitchWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="height: 951px">
        <h1>Perfect pitch, web</h1>
        <p class="lead">Perfect pitch är ett webbprogram som beräknar pitch baserat på individuella parametrar från tomoterapiplan, för att minska effekten av hyperthreading</p>
       
        
        <asp:Panel ID="Panel1" runat="server" style="margin-bottom: 0px" Height="674px" Width="671px" >
            
            <asp:UpdatePanel ID="UpdateResult" UpdateMode="Always"  runat="server">
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DistanceSlide_BoundControl" EventName="TextChanged"/>
                     <asp:AsyncPostBackTrigger ControlID="MFSlide_BoundControl2" EventName="TextChanged"/>
                </Triggers>
              
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" Height="70px" Width="550px">
           <asp:RadioButtonList ID="RButtonFW" runat="server" AutoPostBack="true"  RepeatDirection="Horizontal" OnSelectedIndexChanged="RButtonFW_SelectedIndexChanged">
               <asp:ListItem Value="1.05">1.05 cm</asp:ListItem>
               <asp:ListItem Selected="True" Value="2.5">2.5 cm</asp:ListItem>
               <asp:ListItem Value="5.02">5.02 cm</asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>
            <asp:TextBox ID="DistanceSlide" runat="server" AutoPostBack="true" OnTextChanged="DistanceSlide_TextChanged"></asp:TextBox>
            <asp:Label ID="DistLab" runat="server" Text="Distance to isoaxis"></asp:Label>
            <br />
            <asp:TextBox ID="DistanceSlide_BoundControl" AutoPostBack="true" runat="server" OnTextChanged="DistanceSlide_BoundControl_TextChanged"></asp:TextBox>
          
            <br />
            <asp:TextBox ID="DoseSlide" runat="server"  AutoPostBack="true" OnTextChanged="DoseSlide_TextChanged"></asp:TextBox>
            <ajaxToolkit:SliderExtender ID="DoseSlide_SliderExtender" runat="server"  Maximum="15" Decimals="1" boundcontrolid="DoseSlide_BoundControl0" enablehandleanimation="true" orientation="Horizontal" targetcontrolid="DoseSlide" />
            <asp:Label ID="DistLab0" runat="server" Text="Fraction Dose (Gy)"></asp:Label>
            <br />
            <asp:TextBox ID="DoseSlide_BoundControl0" AutoPostBack="true" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="BlockingSlide" runat="server"  AutoPostBack="true" OnTextChanged="BlockingSlide_TextChanged"></asp:TextBox>
            <ajaxToolkit:SliderExtender ID="BlockingSlide_SliderExtender" runat="server" boundcontrolid="BlockingSlide_BoundControl1" enablehandleanimation="true" orientation="Horizontal" targetcontrolid="BlockingSlide" />
            <asp:Label ID="DistLab1" runat="server"  Text="Blocking(%)"></asp:Label>
            <br />
            <asp:TextBox ID="BlockingSlide_BoundControl1"  AutoPostBack="true" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="MFSlide" runat="server"  AutoPostBack="true" OnTextChanged="MFSlide_TextChanged"></asp:TextBox>
            <ajaxToolkit:SliderExtender ID="MFSlide_SliderExtender" runat="server" Maximum="4" Decimals="1" boundcontrolid="MFSlide_BoundControl2" enablehandleanimation="true" orientation="Horizontal" targetcontrolid="MFSlide" />
            <asp:Label ID="DistLab2" runat="server" Text="Modulation Factor" TabIndex="1"></asp:Label>
            <br />
            <asp:TextBox ID="MFSlide_BoundControl2"  AutoPostBack="true" runat="server" OnTextChanged="MFSlide_BoundControl2_TextChanged"></asp:TextBox>
            <br />
          
            <br />
            
           
                    <asp:TextBox ID="resultbox" runat="server" Text="NaN"></asp:TextBox>
                
               
            
            <asp:TextBox ID="GPtext" runat="server" OnDataBinding="DistanceSlide_BoundControl_TextChanged"></asp:TextBox>
                   
            <br />
                     <asp:Label ID="Label1" runat="server" Text="Pitch/Gantry Period"></asp:Label>
                     <br />

             <ajaxToolkit:sliderextender id="SliderExtender1" runat="server" targetcontrolid="DistanceSlide"
            boundcontrolid="DistanceSlide_BoundControl" Maximum="30" orientation="Horizontal" enablehandleanimation="true"> 
                    </ajaxToolkit:sliderextender> 
              </ContentTemplate>
                    </asp:UpdatePanel>
               
        </asp:Panel>
        </div>

    </asp:Content>
