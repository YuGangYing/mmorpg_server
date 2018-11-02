﻿using System.Collections;
using CSV;


namespace MMO{
[System.Serializable]
public class SkillEffectCSVStructure : BaseCSVStructure {

	//镜像效果id
	[CsvColumn (CanBeNull = true)]
	public int mirror_id{ get;set; }
	//效果名称
	[CsvColumn (CanBeNull = true)]
	public string name{ get; set; }
	//效果描述
	[CsvColumn (CanBeNull = true)]
	public string description{ get; set; }
	//效果Icon
	[CsvColumn (CanBeNull = true)]
	public string icon{ get; set; }
	//基础效果id
	[CsvColumn (CanBeNull = true)]
	public int skill_effect_base_id{ get; set; }
	//效果出现几率
	[CsvColumn (CanBeNull = true)]
	public int effect_possibility{ get; set; }
	//效果类型
	[CsvColumn (CanBeNull = true)]
	public int effect_type{ get; set; }
	//效果开始回合
	[CsvColumn (CanBeNull = true)]
	public int effect_start_round{ get; set; }
	//最大持续回合
	[CsvColumn (CanBeNull = true)]
	public int effect_max_round{ get; set; }
	//在开始effect之前进行计算。绝对值
	public int effect_value{ get; set; }
	//在开始effect之前进行计算。相对值
	public int effect_percent_value{ get; set; }
	//当前的持续回合
	public int effect_current_round{ get; set; }
	//当前持续的战斗回合
	public int effect_current_battle_round{ get; set; }
	//最小绝对值
	[CsvColumn (CanBeNull = true)]
	public int effect_value_min{ get; set; }
	//最大绝对值
	[CsvColumn (CanBeNull = true)]
	public int effect_value_max{ get; set; }
	//最小百分比值
	[CsvColumn (CanBeNull = true)]
	public int effect_percent_value_min{ get; set; }
	//最大百分比值
	[CsvColumn (CanBeNull = true)]
	public int effect_percent_value_max{ get; set; }
	//基于目标最小百分比值
	[CsvColumn (CanBeNull = true)]
	public int effect_percent_target_value_min{ get; set; }
	//基于目标最大百分比值
	[CsvColumn (CanBeNull = true)]
	public int effect_percent_target_value_max{ get; set; }
	[CsvColumn (CanBeNull = true)]
	public string on_awake{ get; set; }
	[CsvColumn (CanBeNull = true)]
	public string on_enter{ get; set; }
	[CsvColumn (CanBeNull = true)]
	public string on_update{ get; set; }
	[CsvColumn (CanBeNull = true)]
	public string on_exit{ get; set; }

	public MSkill skillCSVStructure;

}
}
