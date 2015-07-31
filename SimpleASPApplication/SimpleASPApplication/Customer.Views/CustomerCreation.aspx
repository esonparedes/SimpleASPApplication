<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Views/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerCreation.aspx.cs" Inherits="SimpleASPApplication.Customer.Views.CustomerCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Customer Creation</h3>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Right">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name : "></asp:Label>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" Width="200" CausesValidation="True" CssClass="myTxtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is Required" ForeColor="Red" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                <%--<asp:Label ID="lblReqFirstName" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Right">
                <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name : "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="50" Width="200" CssClass="myTxtBox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Right">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name : "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" Width="200" CssClass="myTxtBox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Right">
                <asp:Label ID="lblBirthday" runat="server" Text="Birthday : "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="ddlMonth" />
                <asp:DropDownList runat="server" ID="ddlDay" />
                <asp:DropDownList runat="server" ID="ddlYear" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Right">
                <asp:Label ID="lblAddress" runat="server" Text="Address : "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" Width="200"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Right">
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnSave" runat="server" Width="200" Text="Save"  CssClass="myButton" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label runat="server" ID="lblStatus" Visible="false" />
</asp:Content>
