<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"><xsl:output method="text" omit-xml-declaration="yes" />
<xsl:template match="RECIPE">
{
    {
      "description": {
      "name": "<xsl:value-of select="NAME"/>",
      "style": "<xsl:value-of select="STYLE/NAME"/>",
      <xsl:if test="STYLE/COLOR_MIN">
        color": "<xsl:value-of select="STYLE/COLOR_MIN"/>",
      </xsl:if>
      <xsl:if test="CALCCOLOUR">
        color": "<xsl:value-of select="CALCCOLOUR"/>",
      </xsl:if>
      "color": "<xsl:value-of select="STYLE/COLOR_MIN"/>",
      "type": "<xsl:value-of select="TYPE"/>",
      "batchSize": "<xsl:value-of select="BATCH_SIZE"/>",
      "efficiency": "<xsl:value-of select="EFFICIENCY"/>",
      "og": "<xsl:value-of select="OG"/>",
      "fg": "<xsl:value-of select="FG"/>"
    },
    "ingredients": {
      "hops": [<xsl:for-each select="HOPS/HOP">
        <xsl:variable name="escaped-notes">
          <xsl:call-template name="replace-string">
            <xsl:with-param name="text" select="NOTES"/>
            <xsl:with-param name="replace" select="'&quot;'" />
            <xsl:with-param name="with" select="'\&quot;'"/>
          </xsl:call-template>
        </xsl:variable>
        {
          "name": "<xsl:value-of select="NAME"/>",
          "alpha": "<xsl:value-of select="ALPHA"/>",
          "amount": "<xsl:value-of select="AMOUNT"/>",
          "time": "<xsl:value-of select="TIME"/>",
          "type": "<xsl:value-of select="FORM"/>",
        "notes": "<xsl:value-of select="normalize-space($escaped-notes)"/>"
        }<xsl:if test="following-sibling::HOP">,</xsl:if>
      </xsl:for-each>
      ],
      "malts": [<xsl:for-each select="FERMENTABLES/FERMENTABLE">
        <xsl:variable name="escaped-notes">
          <xsl:call-template name="replace-string">
            <xsl:with-param name="text" select="NOTES"/>
            <xsl:with-param name="replace" select="'&quot;'" />
            <xsl:with-param name="with" select="'\&quot;'"/>
          </xsl:call-template>
        </xsl:variable>
        {
          "name": "<xsl:value-of select="NAME"/>",
          "amount": "<xsl:value-of select="AMOUNT"/>",
          "type": "<xsl:value-of select="TYPE"/>",
          "notes": "<xsl:value-of select="normalize-space($escaped-notes)"/>"
        }<xsl:if test="following-sibling::FERMENTABLE">,</xsl:if>
      </xsl:for-each>
      ],
      "other": [<xsl:for-each select="MISCS/MISC">
        <xsl:variable name="escaped-notes">
          <xsl:call-template name="replace-string">
            <xsl:with-param name="text" select="NOTES"/>
            <xsl:with-param name="replace" select="'&quot;'" />
            <xsl:with-param name="with" select="'\&quot;'"/>
          </xsl:call-template>
        </xsl:variable>
        {
          "name": "<xsl:value-of select="NAME"/>",
          "amount": "<xsl:value-of select="AMOUNT"/>",
          "type": "<xsl:value-of select="TYPE"/>",
          "notes": "<xsl:value-of select="normalize-space($escaped-notes)"/>"
        }<xsl:if test="following-sibling::MISC">,</xsl:if>
      </xsl:for-each>
      ],
      "yeasts": [<xsl:for-each select="YEASTS/YEAST">
        <xsl:variable name="escaped-notes">
          <xsl:call-template name="replace-string">
            <xsl:with-param name="text" select="NOTES"/>
            <xsl:with-param name="replace" select="'&quot;'" />
            <xsl:with-param name="with" select="'\&quot;'"/>
          </xsl:call-template>
        </xsl:variable>
        {
          "name": "<xsl:value-of select="NAME"/>",
          "notes": "<xsl:value-of select="normalize-space($escaped-notes)"/>"
        }<xsl:if test="following-sibling::YEAST">,</xsl:if>
      </xsl:for-each>
      ]
    },
    "process":{
      "mash": [<xsl:for-each select="MASH/MASH_STEPS/MASH_STEP">
        {
          "name": "<xsl:value-of select="NAME"/>",
          "type": "<xsl:value-of select="TYPE"/>",
          "temperature": "<xsl:value-of select="STEP_TEMP"/>",
          "time": "<xsl:value-of select="STEP_TIME"/>"
        }<xsl:if test="following-sibling::MASH_STEP">,</xsl:if>
      </xsl:for-each>
      ],
      "boil": {
        "boilSize": "<xsl:value-of select="BOIL_SIZE"/>",
        "boilTime": "<xsl:value-of select="BOIL_TIME"/>"
      },
      "fermentation": {
        "temperature": "<xsl:value-of select="PRIMARY_TEMP"/>"
      }
    }
  }
}
</xsl:template>
  <xsl:template name="replace-string">
    <xsl:param name="text"/>
    <xsl:param name="replace"/>
    <xsl:param name="with"/>
    <xsl:choose>
      <xsl:when test="contains($text,$replace)">
        <xsl:value-of select="substring-before($text,$replace)"/>
        <xsl:value-of select="$with"/>
        <xsl:call-template name="replace-string">
          <xsl:with-param name="text"
              select="substring-after($text,$replace)"/>
          <xsl:with-param name="replace" select="$replace"/>
          <xsl:with-param name="with" select="$with"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$text"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>