<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:book="http://library.by/catalog"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:date="urn:sample">
  
    <msxsl:script language="JScript" implements-prefix="date">
       function today()
       {
          return new Date() + '';
       } 
    </msxsl:script> 
  
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/book:catalog">
    
    <xsl:element name="feed">
      
      <xsl:element name="title">Books Library</xsl:element>
      
      <xsl:element name="link">
        <xsl:attribute name="href">
          <xsl:value-of select="'http://library.by/catalog'"/>
        </xsl:attribute>
      </xsl:element>
      
      <xsl:element name="updated">
        <xsl:value-of select="date:today()"/>
      </xsl:element>
      
      <xsl:apply-templates/>
    
    </xsl:element>
  </xsl:template>
    
  <xsl:template match="//book:book">
      <xsl:element name="entry">
        <xsl:element name="title">
          <xsl:value-of select="./book:title"/>
        </xsl:element>
        <xsl:element name="updated">
          <xsl:value-of select="./book:registration_date"/>
        </xsl:element>
          <xsl:if test="./book:isbn and ./book:genre='Computer'">
            <xsl:element name="link">
              <xsl:attribute name="href">
                <xsl:value-of select="concat('http://my.safaribooksonline.com/', ./book:isbn)"/>
              </xsl:attribute>
            </xsl:element>
          </xsl:if>
        </xsl:element>

</xsl:template>

</xsl:stylesheet>
