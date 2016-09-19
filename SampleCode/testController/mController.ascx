<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mController.ascx.cs" Inherits="testController.mController" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
</head>
<body>
    <form runat="server">
        <input runat="server" id="ipt" />
        <asp:Button ID="Button1"
            Text="클릭"
            OnClick="GreetingBtn_Click"
            runat="server" />
        <asp:Repeater ID="rpt_AllMemberList" runat="server" ItemType="testController.TestType">
            <ItemTemplate>
                <tr>
                    <td>
                        <td><%# Item.name %></td>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
