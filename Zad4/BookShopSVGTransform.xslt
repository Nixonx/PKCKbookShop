<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/2000/svg" version="1.0">
   <xsl:output method="html" />
   <xsl:template match="/">
      <svg width="2000" height="1000">
         <foreignObject x="0" y="0" width="1000" height="1000">
            <body xmlns="http://www.w3.org/1999/xhtml">
               <table>
                  <tr>
                     <th>First name</th>
                     <th>Last name</th>
                     <th>Number of books</th>
                     <th style="width: 100%; float: left;">Value of books</th>
                  </tr>
                  <xsl:for-each select="Raport/Author">
                     <tr>
                        <td>
                           <xsl:value-of select="firstName" />
                        </td>
                        <td>
                           <xsl:value-of select="lastName" />
                        </td>
                        <td>
                           <xsl:value-of select="numberOfBooks" />
                           <svg xmlns="http://www.w3.org/2000/svg" width="2000" height="18">
                              <rect x="5px" y="5px" height="{10*numberOfBooks}" width="{1000}" fill="green" />
                              <animate attributeName="width" attributeType="XML" begin="0s" dur="1s" from="0" to="{10*numberOfBooks}" repeatCount="1" fill="freeze" />
                           </svg>
                        </td>
                        <td>
                           <xsl:value-of select="valueOfBooks" />
                           <svg xmlns="http://www.w3.org/2000/svg" width="2000" height="18">
                              <rect x="5px" y="5px" height="{10}" width="{1000}" fill="red" />
                              <animate attributeName="width" attributeType="XML" begin="0s" dur="1s" from="0" to="{2*valueOfBooks}" repeatCount="1" fill="freeze" />
                           </svg>
                        </td>
                     </tr>
                  </xsl:for-each>
               </table>
            </body>
         </foreignObject>
      </svg>
   </xsl:template>
</xsl:stylesheet>
