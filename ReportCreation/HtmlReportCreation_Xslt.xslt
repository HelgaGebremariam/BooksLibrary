<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:book="http://library.by/catalog"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:date="urn:sample"
                xmlns:ext="http://library.by/catalog">

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

      <xsl:element name="body">
        <xsl:element name="h1">
          <xsl:value-of select="concat('Books Library Report ', date:today())"/>
        </xsl:element>

        <xsl:element name="h1">Computer</xsl:element>
        
        <xsl:element name="table">
          <xsl:element name="tr">
            <xsl:element name="th">Author</xsl:element>
            <xsl:element name="th">Name</xsl:element>
            <xsl:element name="th">Publish Date</xsl:element>
            <xsl:element name="th">Registration Date</xsl:element>
          </xsl:element>
          <xsl:apply-templates select="//book:book[book:genre='Computer']"/>
        </xsl:element>

        <xsl:element name="h1">
          <xsl:value-of select="concat('Total: ', count(//book:book[book:genre='Computer']))"/>
        </xsl:element>

        <xsl:element name="h1">Fantasy</xsl:element>

        <xsl:element name="table">
          <xsl:element name="tr">
            <xsl:element name="th">Author</xsl:element>
            <xsl:element name="th">Name</xsl:element>
            <xsl:element name="th">Publish Date</xsl:element>
            <xsl:element name="th">Registration Date</xsl:element>
          </xsl:element>
          <xsl:apply-templates select="//book:book[book:genre='Fantasy']"/>
        </xsl:element>

        <xsl:element name="h1">
          <xsl:value-of select="concat('Total: ', count(//book:book[book:genre='Fantasy']))"/>
        </xsl:element>


        <xsl:element name="h1">Horror</xsl:element>

        <xsl:element name="table">
          <xsl:element name="tr">
            <xsl:element name="th">Author</xsl:element>
            <xsl:element name="th">Name</xsl:element>
            <xsl:element name="th">Publish Date</xsl:element>
            <xsl:element name="th">Registration Date</xsl:element>
          </xsl:element>
          <xsl:apply-templates select="//book:book[book:genre='Horror']"/>
        </xsl:element>

        <xsl:element name="h1">
          <xsl:value-of select="concat('Total: ', count(//book:book[book:genre='Horror']))"/>
        </xsl:element>

        <xsl:element name="h1">Romance</xsl:element>

        <xsl:element name="table">
          <xsl:element name="tr">
            <xsl:element name="th">Author</xsl:element>
            <xsl:element name="th">Name</xsl:element>
            <xsl:element name="th">Publish Date</xsl:element>
            <xsl:element name="th">Registration Date</xsl:element>
          </xsl:element>
          <xsl:apply-templates select="//book:book[book:genre='Romance']"/>
        </xsl:element>

        <xsl:element name="h1">
          <xsl:value-of select="concat('Total: ', count(//book:book[book:genre='Romance']))"/>
        </xsl:element>

        <xsl:element name="h1">Science Fiction</xsl:element>

        <xsl:element name="table">
          <xsl:element name="tr">
            <xsl:element name="th">Author</xsl:element>
            <xsl:element name="th">Name</xsl:element>
            <xsl:element name="th">Publish Date</xsl:element>
            <xsl:element name="th">Registration Date</xsl:element>
          </xsl:element>
          <xsl:apply-templates select="//book:book[book:genre='Science Fiction']"/>
        </xsl:element>

        <xsl:element name="h1">
          <xsl:value-of select="concat('Total: ', count(//book:book[book:genre='Science Fiction']))"/>
        </xsl:element>

        <xsl:element name="h1">
          <xsl:value-of select="concat('Total (all books): ', count(//book:book))"/>
        </xsl:element>
        
      </xsl:element>
      
    </xsl:element>
  </xsl:template>
  
  <xsl:template match="//book:book[book:genre='Computer']">
    <xsl:element name="tr">
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
    </xsl:element>
  </xsl:template>
  
    <xsl:template match="//book:book[book:genre='Fantasy']">
    <xsl:element name="tr">
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
    </xsl:element>
  </xsl:template>

  <xsl:template match="//book:book[book:genre='Romance']">
    <xsl:element name="tr">
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
    </xsl:element>
  </xsl:template>

  <xsl:template match="//book:book[book:genre='Horror']">
    <xsl:element name="tr">
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
    </xsl:element>
  </xsl:template>

  <xsl:template match="//book:book[book:genre='Science Fiction']">
    <xsl:element name="tr">
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
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>