<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardEditorFormControl.aspx.cs" Inherits="MemoEngine.DotNetNote.Controls.BoardEditorFormControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>글작성</h3>
            <table>
                <tr>
                    <td>이름</td>
                    <td><asp:TextBox ID="txb_name" runat="server" MaxLength="10" CssClass="form-control"/></td>
                </tr>
                <tr>
                    <td>이메일</td>
                    <td><asp:TextBox ID="txb_email" runat="server" MaxLength="10" CssClass="form-control"/></td>
                </tr>
                <tr>
                    <td>홈페이지</td>
                    <td><asp:TextBox ID="txb_homepage" runat="server" MaxLength="10" CssClass="form-control"/></td>
                </tr>
                  <tr>
                    <td>제목</td>
                    <td><asp:TextBox ID="txb_title" runat="server" MaxLength="10" CssClass="form-control"/></td>
                </tr>
                 <tr>
                    <td>내용</td>
                    <td><asp:TextBox ID="txb_content" runat="server" MaxLength="10" CssClass="form-control" TextMode="MultiLine"/></td>
                </tr>
                    <tr>
                    <td>파일 첨부</td>
                    <td>
                        <asp:CheckBox ID="cbx_fileAttach" runat="server" OnCheckedChanged="cbx_fileAttach_CheckedChanged" Text="파일첨부 여부" AutoPostBack="true" />
                        <br />
                        <asp:Panel ID="pnl_file" runat="server" Visible="false">
                            <asp:FileUpload ID="ful_file" runat="server" />
                            <asp:Label ID="lbl_fileName" runat="server" Visible="false" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>인코딩</td>
                    <td>
                        <asp:RadioButtonList ID="rbl_encoding" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="Text" Selected="True" Text="Text"/>
                        <asp:ListItem Value="HTML" Text="HTML"/>
                        <asp:ListItem Value="Mixed" Text="Mixed"/>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td>비밀번호</td>
                    <td><asp:TextBox ID="txb_password" runat="server" TextMode="Password" EnableViewState="false" MaxLength="20"></asp:TextBox></td>
                </tr>

                <% 
                    if (!Page.User.Identity.IsAuthenticated)
                    {
                %>
                    <tr>
                        <td>보안코드</td>
                        <td><asp:TextBox ID="txb_code" runat="server" CssClass="form-control" EnableViewState="false" MaxLength="20"></asp:TextBox>
                        <br />
                        <asp:Image ID="img_code" runat="server" imageUrl="~/DotNetNote/ImageText" />
                        <asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                <%
                    }
                %>
                <tr>
                    <td><asp:Button ID="btn_save" runat="server" Text="저장" CssClass="btn btn-primary" OnClick="btn_save_Click" /></td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
