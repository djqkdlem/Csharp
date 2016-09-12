<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <HTML>
      <BODY leftmargin="10"  scroll="Auto">
        <FONT COLOR="BLUE" SIZE="3">
          ◈ <B>개인정보처리자 정보</B>◈
        </FONT>
        <TABLE cellspacing="1" cellpadding="3" border="1" width="100%" bgcolor="#2E7BA9" style="font-size:12; font-color:482400">
          <tr bgcolor="#99B9E0">
            <td style="color:ffffff;font-weight:bold;text-align:center">회사</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">사번</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">이름</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">휴대폰(000-0000-0000)</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">최종 서약일</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">최종 교육이수일</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">당해년도 교육횟수</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">이수여부</td>
            <td style="color:ffffff;font-weight:bold;text-align:center">퇴사사유</td>
          </tr>
          <xsl:for-each select="NewDataSet/Table">
            <TR bgcolor="#ffffff">
              <td align="center" style="mso-number-format:'\@';" id="CompanyName">
                <xsl:value-of select="CompanyName"/>
              </td>
              <td align="center" style="mso-number-format:'\@';" id="EmpID">
                <xsl:value-of select="EmpID"/>
              </td>
              <td align="center" id="Name">
                <xsl:value-of select="Name"/>
              </td>
              <td align="center" id="MobileTel">
                <xsl:value-of select="MobileTel"/>
              </td>
              <td align="center" id="FinalContractDate">
                <xsl:value-of select="substring(FinalContractDate, 0, 11)"/>
              </td>
              <td align="center" id="FinalEducationDate">
                <xsl:value-of select="substring(FinalEducationDate, 0, 11)"/>
              </td>
              <td align="center" id="CurrentYearEducationCount">
                <xsl:value-of select="CurrentYearEducationCount"/>
              </td>
              <td align="center" id="AccessYN">
                <xsl:value-of select="AccessYN"/>
              </td>
              <td align="center" style="mso-number-format:'\@';" id="DeletedReason">
                <xsl:value-of select="DeletedReason"/>
              </td>
            </TR>
          </xsl:for-each>
        </TABLE>
      </BODY>
    </HTML>
  </xsl:template>
</xsl:stylesheet>
