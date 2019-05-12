<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
   <xsl:output method="text" indent="yes" />
   <xsl:template match="/">
      Data of generated raport:
      <xsl:value-of select="Raport/RaportGenerateData" />
      Total number of authors:
      <xsl:value-of select="Raport/Authors" />
      Total number of books:
      <xsl:value-of select="Raport/Books" />
      Total number of bookshelfs:
      <xsl:value-of select="Raport/Bookshelfs" />
      Total number of booktypes:
      <xsl:value-of select="Raport/BookTypes" />
      <xsl:text />
      <xsl:text />
      <xsl:text>First name     | Last name     | Number of books     | Value of books</xsl:text>
      <xsl:for-each select="Raport/Author">
         <xsl:text />
         <xsl:value-of select="substring(concat(firstName, '                            '), 1, 17)" />
         <xsl:value-of select="substring(concat(lastName, '                            '), 1, 16)" />
         <xsl:value-of select="substring(concat(numberOfBooks, '                            '), 1, 22)" />
         <xsl:value-of select="concat(valueOfBooks, '')" />
      </xsl:for-each>
   </xsl:template>
</xsl:stylesheet>
