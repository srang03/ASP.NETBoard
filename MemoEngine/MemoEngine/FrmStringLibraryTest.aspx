<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmStringLibraryTest.aspx.cs" Inherits="MemoEngine.FrmStringLibraryTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txb_input" runat="server" />
            <asp:Button ID="btn_save" runat="server" Text="실행" OnClick="btn_save_Click" />
            <asp:Label ID="lbl_result" runat="server" />

            <asp:TextBox ID="txb_size" runat="server" />
            <asp:Button ID="btn_size" runat="server" Text="실행" OnClick="btn_size_Click" />
            <asp:Label ID="lbl_sizeResult" runat="server" />
        </div>
    </form>
</body>
</html>
