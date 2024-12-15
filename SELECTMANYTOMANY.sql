 use tedrisprosesi;
 SELECT `s`.`SubjectId`, `s`.`TecherId`, `t`.`Id`, `t`.`CafedraId`, `t`.`Firstname`, `t`.`Lastname`, `t`.`PIN`, `s0`.`Id`, `s0`.`CafedraId`, `s0`.`Name`
      FROM `subjecttecher` AS `s`
      LEFT JOIN `teacher` AS `t` ON `s`.`TecherId` = `t`.`Id`
      LEFT JOIN `subject` AS `s0` ON `s`.`SubjectId` = `s0`.`Id`