<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <HTML>
      <BODY leftmargin="10"  scroll="Auto">
        <FONT COLOR="BLUE" SIZE="3">
          ◈ <B>접속기록 정보</B>◈
        </FONT>
        <TABLE cellspacing="1" cellpadding="3" border="1" width="100%" bgcolor="#2E7BA9" style="font-size:12; font-color:482400">
          <tr bgcolor="#99B9E0">
            <td style="color:ffffff;font-weight:bold;text-align:center">정보시스템</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">이름</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">ID</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">행위 URL</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">행위 명</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">행위</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">개인정보</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">접속시간</td>
          </tr>
          <xsl:for-each select="NewDataSet/Table1">
            <TR bgcolor="#ffffff">
              <td align="center" id="SystemName">
                <xsl:value-of select="SystemName"/>
              </td>
              <td align="center"  id="UserName">
                <xsl:value-of select="UserName"/>
              </td>
              <td align="center" id="UserID">
                <xsl:value-of select="UserID"/>
              </td>
              <td align="center" id="ActionUrl">
                <xsl:value-of select="ActionUrl"/>
              </td>
              <td align="center" id="ActionName">
                <xsl:value-of select="ActionName"/>
              </td>
              <td align="center" id="ActionStateText">
                <xsl:value-of select="ActionStateText"/>
              </td>
              <td align="center" id="PersonalInformationYN">
                <xsl:value-of select="PersonalInformationYN"/>
              </td>
              <td align="center" id="ActionDateTime">
                <xsl:value-of select="ActionDateTime"/>
              </td>
            </TR>
          </xsl:for-each>
        </TABLE>
      </BODY>
    </HTML>
  </xsl:template>
</xsl:stylesheet>
