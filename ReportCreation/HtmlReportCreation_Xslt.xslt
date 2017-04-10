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
    <html>

      <head>
        <title>
          <xsl:value-of select="concat('Books Library Report ', date:today())"/>
        </title>
      </head>

      <body>
        <h1>
          <xsl:value-of select="concat('Books Library Report ', date:today())"/>
        </h1>

        <xsl:for-each select="//book:genre[not(.=preceding::*)]">
          <xsl:call-template name="out_genre">
            <xsl:with-param name="genre_name" select="."></xsl:with-param>
          </xsl:call-template>
        </xsl:for-each>

        <h1>
          <xsl:value-of select="concat('Total (all books): ', count(//book:book))"/>
        </h1>
        
      </body>

    </html>

  </xsl:template>

  <xsl:template name="out_genre">
    <xsl:param name="genre_name" />

    <h1>
      <xsl:value-of select="$genre_name"/>
    </h1>

    <table>
      <tr>
        <th>Author</th>
        <th>Name</th>
        <th>Publish Date</th>
        <th>Registration Date</th>
      </tr>
      <tr>
        <xsl:apply-templates select="//book:book[book:genre=$genre_name]"/>
      </tr>
    </table>

    <h1>
      <xsl:value-of select="concat('Total: ', count(//book:book[book:genre=$genre_name]))"/>
    </h1>

  </xsl:template>

  <xsl:template match="//book:book">
    <th>
      <xsl:value-of select="./book:author"/>
    </th>
    <th>
      <xsl:value-of select="./book:title"/>
      </th>
    <th>
      <xsl:value-of select="./book:publish_date"/>
      </th>
    <th>
      <xsl:value-of select="./book:registration_date"/>
    </th>
  </xsl:template>

</xsl:stylesheet>