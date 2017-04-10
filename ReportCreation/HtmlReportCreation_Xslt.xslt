<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:book="http://library.by/catalog"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:date="urn:sample"
                xmlns:ext="http://library.by/catalog"
                xmlns:fn="http://www.w3.org/2005/xpath-functions">

  <xsl:output method="html" indent="yes"/>

  <msxsl:script language="JScript" implements-prefix="date">
    function today()
    {
    return new Date() + '';
    }
  </msxsl:script>

  <xsl:template match="//book:catalog">
    <xsl:element name="html">

      <xsl:element name="head">
        <xsl:element name="title">
          <xsl:value-of select="concat('Books Library Report ', date:today())"/>
        </xsl:element>
      </xsl:element>

      <body>
        <xsl:element name="h1">
          <xsl:value-of select="concat('Books Library Report ', date:today())"/>
        </xsl:element>

        <xsl:element name="h1">
          <xsl:value-of select="concat('Total (all books): ', count(//book:book))"/>
        </xsl:element>
        <xsl:for-each select="//book:genre[not(.=preceding::*)]">
          <xsl:call-template name="out_genre">
            <xsl:with-param name="genre_name" select="."></xsl:with-param>
          </xsl:call-template>
        </xsl:for-each>
      </body>

    </xsl:element>

  </xsl:template>

  <xsl:template name="out_genre">
    <xsl:param name="genre_name" />

    <xsl:element name="h1">
      <xsl:value-of select="$genre_name"/>
    </xsl:element>

    <xsl:element name="table">
      <xsl:element name="tr">
        <xsl:element name="th">Author</xsl:element>
        <xsl:element name="th">Name</xsl:element>
        <xsl:element name="th">Publish Date</xsl:element>
        <xsl:element name="th">Registration Date</xsl:element>
      </xsl:element>
      <xsl:element name="tr">
        <xsl:apply-templates select="//book:book[book:genre=$genre_name]"/>
      </xsl:element>
    </xsl:element>

    <xsl:element name="h1">
      <xsl:value-of select="concat('Total: ', count(//book:book[book:genre=$genre_name]))"/>
    </xsl:element>

  </xsl:template>

  <xsl:template match="//book:book">
    <xsl:element name="th">
      <xsl:value-of select="./book:author"/>
    </xsl:element>
    <xsl:element name="th">
      <xsl:value-of select="./book:title"/>
    </xsl:element>
    <xsl:element name="th">
      <xsl:value-of select="./book:publish_date"/>
    </xsl:element>
    <xsl:element name="th">
      <xsl:value-of select="./book:registration_date"/>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>