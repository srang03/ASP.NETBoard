<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNetBoard.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>메인화면</h2>
            <asp:LoginView ID="lgv_main" runat="server">
                <AnonymousTemplate>
                    <asp:LoginStatus ID="lgs_none" runat="server" LoginText="로그인" /> |
                    <asp:HyperLink ID="hpl_none" runat="server" NavigateUrl="~/Register.aspx" Text="회원가입" />
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <asp:LoginStatus ID="lgs_logined" runat="server" LoginText="로그아웃" Visible="false"/>
                    <asp:HyperLink ID="hpl_logined" runat="server" NavigateUrl="~/Logout.aspx" Text="로그아웃"/> |
                    <asp:HyperLink ID="hpl_myinfo" runat="server" NavigateUrl="~/UserInfo.aspx"> <asp:LoginName runat="server" ID="lgn_user" /></asp:HyperLink>

                </LoggedInTemplate>
            </asp:LoginView>

        </div>
    </form>
</body>
</html>
