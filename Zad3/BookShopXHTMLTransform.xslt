<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns="http://www.w3.org/1999/xhtml">
<xsl:template match="/">
  <html>
  <body>
  <h2>Authors raport</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th>First name</th>
        <th>Last name</th>
        <th>Number of books</th>
        <th>Value of books</th>
      </tr>
      <xsl:for-each select="Raport/Author">
      <tr>
        <td><xsl:value-of select="firstName"/></td>
        <td><xsl:value-of select="lastName"/></td>
        <td><xsl:value-of select="numberOfBooks"/></td>
        <td><xsl:value-of select="valueOfBooks"/></td>
      </tr>
      </xsl:for-each>
    </table>
<div id="statistics">
<div>Data of generated raport: <xsl:value-of select="Raport/RaportGenerateData"/></div>
<div>Total number of authors: <xsl:value-of select="Raport/Authors"/></div>
<div>Total number of books: <xsl:value-of select="Raport/Books"/></div>
<div>Total number of bookshelfs: <xsl:value-of select="Raport/Bookshelfs"/></div>
<div>Total number of booktypes: <xsl:value-of select="Raport/BookTypes"/></div>
</div>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>
