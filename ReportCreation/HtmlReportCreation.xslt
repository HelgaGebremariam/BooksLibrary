<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:book="http://library.by/catalog"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:date="urn:sample"
                xmlns:ext="http://library.by/catalog">

  <xsl:output method="html" indent="yes"/>


  <xsl:template match="//book:book">

    
    <xsl:value-of disable-output-escaping="yes" select="ext:AddReportRow(./book:genre, ./book:author, ./book:title, ./book:publish_date, ./book:registration_date)"/>

  </xsl:template>

</xsl:stylesheet>