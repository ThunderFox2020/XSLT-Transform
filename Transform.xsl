<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    
    <xsl:output method="xml" encoding="UTF-8" indent="yes"/>
    
    <xsl:key name="groupKey" match="/list/item" use="@group"/>
    
    <xsl:template match="/">
        <groups>
            <xsl:for-each select="/list/item">
                <xsl:sort select="@group" data-type="number"/>
                <xsl:variable name="currentGroup" select="@group"/>
                <xsl:if test="generate-id() = generate-id(key('groupKey', $currentGroup))">
                    <group name="{$currentGroup}">
                        <xsl:for-each select="key('groupKey', $currentGroup)">
                            <xsl:sort select="@name" data-type="number"/>
                            <item name="{@name}"/>
                        </xsl:for-each>
                    </group>
                </xsl:if>
            </xsl:for-each>
        </groups>
    </xsl:template>
    
</xsl:stylesheet>