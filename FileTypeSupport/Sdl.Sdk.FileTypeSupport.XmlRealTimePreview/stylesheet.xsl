<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" indent="yes" encoding="utf-16"/> 
<xsl:template match="/"> 
	<html>
		<body bgcolor="white">			
			<xsl:apply-templates select="/document"/>
		</body>
	</html>		
</xsl:template> 
<!-- ***********************************************************************-->
<xsl:template match="title">
	<h2><xsl:value-of select="."/></h2>
</xsl:template>

<xsl:template match="para">
	<p><xsl:value-of select="."/></p>
</xsl:template>

<xsl:template match="list">
	<ol><xsl:apply-templates select="item"/></ol>
</xsl:template>

<xsl:template match="item">
	<li><xsl:apply-templates/></li>
</xsl:template>

<xsl:template match="emphasis">
	<b><xsl:value-of select="."/></b>
</xsl:template>
<!-- ***********************************************************************-->
</xsl:stylesheet>