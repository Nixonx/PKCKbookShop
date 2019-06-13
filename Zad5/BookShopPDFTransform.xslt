<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" version="2.0">
   <xsl:template match="/">
      <fo:root>
         <fo:layout-master-set>
            <fo:simple-page-master master-name="A4" page-height="29cm" page-width="21cm" margin-bottom="2cm" margin-top="2cm" margin-left="1.5cm" margin-right="1.5cm">
               <fo:region-body margin-top="1cm" />
               <fo:region-before extent="3.5cm" />
               <fo:region-after extent="1.5cm" />
            </fo:simple-page-master>
         </fo:layout-master-set>
         <fo:page-sequence master-reference="A4">
            <fo:flow flow-name="xsl-region-body">
		<fo:block>
			Authors:
		</fo:block>
                <fo:table>
                  <xsl:for-each select="//Author">
                     <fo:table-column column-width="30mm" />
                  </xsl:for-each>
                  <fo:table-header>
                     <fo:table-row>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" width="30mm" font-size="14px">ID</fo:block>
                        </fo:table-cell>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" width="30mm" font-size="14px">First name</fo:block>
                        </fo:table-cell>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" width="30mm" font-size="14px">Last name</fo:block>
                        </fo:table-cell>
                     </fo:table-row>
                  </fo:table-header>
                  <fo:table-body>
                     <xsl:for-each select="//Author">
                        <fo:table-row>
                           <fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="id" />
                              </fo:block>
                           </fo:table-cell>
                           <fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="firstName" />
                              </fo:block>
                           </fo:table-cell>
                           <fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="lastName" />
                              </fo:block>
                           </fo:table-cell>
                        </fo:table-row>
                     </xsl:for-each>
                  </fo:table-body>
               </fo:table>
               <fo:block linefeed-treatment="preserve">Books</fo:block>
               <fo:table>
                  <xsl:for-each select="//Book">
                     <fo:table-column column-width="30mm" />
                  </xsl:for-each>
                  <fo:table-header>
                     <fo:table-row>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" width="30mm" font-size="14px">title</fo:block>
                        </fo:table-cell>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" width="30mm" font-size="14px">price</fo:block>
                        </fo:table-cell>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" width="30mm" font-size="14px">pages</fo:block>
                        </fo:table-cell>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" font-size="14px">releaseData</fo:block>
                        </fo:table-cell>
                        <fo:table-cell border="1px solid black">
                           <fo:block font-weight="bold" font-size="14px">author</fo:block>
                        </fo:table-cell>
                     </fo:table-row>
                  </fo:table-header>
                  <fo:table-body>
                     <xsl:for-each select="//Book">
                        <fo:table-row>
                           <fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="title" />
                              </fo:block>
                           </fo:table-cell>
                           <fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="price" />
                              </fo:block>
                           </fo:table-cell>
                           <fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="pages" />
                              </fo:block>
                           </fo:table-cell>
                           <fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="releaseDate" />
                              </fo:block>
                           </fo:table-cell>
  				<fo:table-cell border="1px solid black">
                              <fo:block>
                                 <xsl:value-of select="author/firstName" />
                              </fo:block>
<fo:block>
                                 <xsl:value-of select="author/lastName" />
                              </fo:block>
<fo:block>
                                 <xsl:value-of select="author/id" />
                              </fo:block>
                           </fo:table-cell>
                        </fo:table-row>
                     </xsl:for-each>
                  </fo:table-body>
               </fo:table>
            </fo:flow>
         </fo:page-sequence>
      </fo:root>
   </xsl:template>
</xsl:stylesheet>
