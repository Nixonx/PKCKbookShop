<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
      <Raport>
        <RaportGenerateData>
          <xsl:value-of  select="current-dateTime()"/>
        </RaportGenerateData>
      <Authors>
       <xsl:value-of select="count(//Author)" /> 
      </Authors>
      <Books>
       <xsl:value-of select="count(//Book)" /> 
      </Books>
      <Bookshelfs>
      <xsl:value-of select="count(//Bookshelf)" />  
      </Bookshelfs>
        <BookTypes>
          <xsl:value-of select="count(distinct-values(//Book/type))"/>
        </BookTypes>
      <xsl:for-each select="//Author">
        <Author>
          <firstName>
            <xsl:value-of select="firstName"/>
          </firstName>
          <lastName>
            <xsl:value-of select="lastName"/>
          </lastName>
          <numberOfBooks>
            <xsl:value-of select="count(//Book[@authorIdRef=current()/@authorId])" />
          </numberOfBooks>
          <valueOfBooks>
            <xsl:value-of select="sum((//Book[@authorIdRef=current()/@authorId]/price)[number(.) = .])"/>
          </valueOfBooks>
        </Author>
      </xsl:for-each>
      </Raport>
    </xsl:template>
</xsl:stylesheet>
