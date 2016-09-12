<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Excel.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function fn_ExcelDownloadClick() {
            if (!confirm("엑셀 다운로드를 하시겠습니까?"))
                return false;

            var postBackStr = "<%= Page.GetPostBackEventReference(this.btnExcelDownload) %>";
            eval(postBackStr);
        }
    </script>
    <style>
        td {
            text-align: center;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div>
            <table>
                <asp:Repeater ID="rptAccessRecordList" runat="server" ItemType="Excel.AccessRecordType">
                    <HeaderTemplate>
                        <colgroup>
                            <col style="width: 2%">
                            <!-- 01 -->
                            <col style="width: 13%">
                            <!-- 02 -->
                            <col style="width: 9%">
                            <!-- 03 -->
                            <col style="width: 10%">
                            <!-- 04 -->
                            <col style="width: 13%">
                            <!-- 05 -->
                            <col style="width: 16%">
                            <!-- 06 -->
                            <col style="width: 11%">
                            <!-- 07 -->
                            <col style="width: 7%">
                            <!-- 08 -->
                            <col style="width: *">
                            <!-- 09 -->
                        </colgroup>
                        <thead>
                            <th>No.</th>
                            <th>정보시스템</th>
                            <th>이름</th>
                            <th>ID</th>
                            <th>행위 URL</th>
                            <th>행위 명</th>
                            <th>행위</th>
                            <th>개인<br />
                                정보</th>
                            <th>접속시간</th>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.RowNum %></td>
                            <td><%# Item.SystemName %></td>
                            <td><%# Item.UserName %></td>
                            <td class="keypoint"><%# Item.UserID %></td>
                            <td><%# Item.ActionUrl %></td>
                            <td><%# Item.ActionName %></td>
                            <td><%# Item.ActionStateText %></td>
                            <td><%# Item.PersonalInformationYN %></td>
                            <td><%# Item.ActionDateTime %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </table>
            <div class="subject_btset">
                <a href="javascript:;" class="btl" alt="엑셀 다운로드" onclick="fn_ExcelDownloadClick();">엑셀 다운로드</a>
            </div>
        </div>

        <div style="display: none">
            <asp:LinkButton ID="btnExcelDownload" runat="server" OnClick="btnExcelDownload_Click" />
        </div>
    </form>
</body>
</html>
