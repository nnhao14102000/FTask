using System.Collections.Generic;
using System;
using System.Linq;
using FTask.Database.Models;

namespace FTask.Services.Helpers
{
    public static class DBInitializer
    {
        public static void Initialize(FTaskContext context)
        {
            // Check database created
            context.Database.EnsureCreated();

            // Auto seed data if Majors have no data
            if (!context.Majors.Any())
            {
                var majors = new Major[]{
                    new Major{MajorId = "BIT_SE", MajorName = "Bachelor of Software engineer"},
                    new Major{MajorId = "BIT_IA", MajorName = "Bachelor of Information assurance"},
                    new Major{MajorId = "BBA_FIN", MajorName = "Business Administration Finance"},
                    new Major{MajorId = "BBA_IB", MajorName = "Business Administration International Business"},
                    new Major{MajorId = "BBA_MC", MajorName = "Business Administration Multimedia communication"},
                    new Major{MajorId = "BBA_MKT", MajorName = "Business Administration Marketing"},
                    new Major{MajorId = "BEL", MajorName = "Bachelor of English Language"},
                    new Major{MajorId = "BGD", MajorName = "Bachelor of Graphic Design"},
                    new Major{MajorId = "BJP", MajorName = "Bachelor of Japanese Language"},
                    new Major{MajorId = "BKR", MajorName = "Bachelor of Korean Language"},
                    new Major{MajorId = "BMC", MajorName = "Bachelor of Multimedia Communication"},
                };

                context.AddRange(majors);
                context.SaveChanges();

            }

            // Auto seed data if Semesters have no data
            if (!context.Semesters.Any())
            {
                var semesters = new Semester[]{
                    new Semester{SemesterId="FA_20",SemesterName="Fall 2020", StartDate=DateTime.Parse("2020-08-04T00:00:00"), EndDate=DateTime.Parse("2020-11-04T00:00:00"), IsComplete = true},
                    new Semester{SemesterId="SP_21",SemesterName="Spring 2021", StartDate=DateTime.Parse("2021-01-04T00:00:00"), EndDate=DateTime.Parse("2021-01-04T00:00:00"), IsComplete = true},
                    new Semester{SemesterId="SU_21",SemesterName="Summer 2021", StartDate=DateTime.Parse("2021-05-04T00:00:00"), EndDate=DateTime.Parse("2021-08-04T00:00:00"), IsComplete = false}
                };

                context.AddRange(semesters);
                context.SaveChanges();

            }

            // Auto seed data if Students have no data
            if (!context.Students.Any())
            {
                var students = new Student[]{
                    new Student{StudentId="SE140742", StudentName="Nguyen Nhut Hao", StudentEmail="HaonnSE140742@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE130720", StudentName="Tran Van Kien", StudentEmail="KientvSE130720@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE140329", StudentName="Nguyen Minh Tri", StudentEmail="TrinmSE140329@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE61637", StudentName="Tran Ngoc Nha", StudentEmail="NhatnSE61637@fpt.edu.vn", MajorId="BIT_SE"},

                    new Student{StudentId="SE111111", StudentName="Nguyen Van An", StudentEmail="AnnvSE111111@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE222222", StudentName="Nguyen Van Hai", StudentEmail="HainvSE222222@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE333333", StudentName="Nguyen Van Binh", StudentEmail="BinhnvSE333333@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE444444", StudentName="Nguyen Van Tai", StudentEmail="TainvSE444444@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE555555", StudentName="Nguyen Van Ngan", StudentEmail="NgannvSE555555@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE666666", StudentName="Nguyen Van Son", StudentEmail="SonnvSE666666@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE777777", StudentName="Nguyen Thai Binh", StudentEmail="BinhntSE777777@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE888888", StudentName="Nguyen Van Thi", StudentEmail="ThinvSE888888@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE999999", StudentName="Nguyen Van Quan", StudentEmail="QuannvSE999999@fpt.edu.vn", MajorId="BIT_IA"},
                };

                context.AddRange(students);
                context.SaveChanges();

            }

            // Auto seed data if SubjectGroup have no data
            if (!context.SubjectGroups.Any())
            {
                var subjectGroups = new SubjectGroup[]{
                    new SubjectGroup{SubjectGroupName = "Computing Fundamentals"},
                    new SubjectGroup{SubjectGroupName = "Software Engineering"},
                    new SubjectGroup{SubjectGroupName = "Politics"},
                    new SubjectGroup{SubjectGroupName = "Digital Art & Design"},
                    new SubjectGroup{SubjectGroupName = "Economics"},
                    new SubjectGroup{SubjectGroupName = "Finance"},
                    new SubjectGroup{SubjectGroupName = "General Management"},
                    new SubjectGroup{SubjectGroupName = "Information Assurance"},
                    new SubjectGroup{SubjectGroupName = "International Business"},
                    new SubjectGroup{SubjectGroupName = "Japanese"},
                    new SubjectGroup{SubjectGroupName = "Marketing"},
                    new SubjectGroup{SubjectGroupName = "Mathematics"},
                    new SubjectGroup{SubjectGroupName = "Accounting"},
                    new SubjectGroup{SubjectGroupName = "English"},
                    new SubjectGroup{SubjectGroupName = "Multiple Media Communication"},
                };

                context.AddRange(subjectGroups);
                context.SaveChanges();

            }

            // Auto seed data if Subjects have no data
            if (!context.Subjects.Any())
            {
                var subjects = new Subject[]{
                    new Subject{SubjectId="ISC301", SubjectName="E-Commerce", Source="...", SubjectGroupId=11},
                    new Subject{SubjectId="ACC101", SubjectName="Principles of Accounting", Source="Fundamental Accounting Principles, 20th Edition", SubjectGroupId=13},
                    new Subject{SubjectId="SWD391", SubjectName="Software Architecture and Design", Source="Software architecture design patterns in Java", SubjectGroupId=2},
                    new Subject{SubjectId="HCI201", SubjectName="Human-Computer Interaction", Source="...", SubjectGroupId=2},
                    new Subject{SubjectId="PRM391", SubjectName="Mobile Programming", Source="...", SubjectGroupId=2},

                    new Subject{SubjectId="CEA201", SubjectName="Computer Organization and Architecture", Source="Computer Organization and Architecture 10th", SubjectGroupId=1},
                    new Subject{SubjectId="CSI101", SubjectName="Introduction to computing", Source="Connecting with Computer Science", SubjectGroupId=1},
                };

                context.AddRange(subjects);
                context.SaveChanges();

            }

            // Auto seed data if Topics have no data
            if (!context.Topics.Any())
            {
                var topics = new Topic[]{
                    new Topic{TopicName="Chapter 01 Overview of Electronic Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 02 E-Commerce Mechanisms, Infrastructure, and Tools", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 03 Retailing in Electronic Commerce Products and Services", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 04 B2B E-Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 05 Innovative EC Systems From E-Government to E-Learning, Collaborative Commerce, and C2C Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 06 Mobile Commerce and Ubiquitous Computing", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 07 Social Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 08 Marketing-and-Advertising", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 09 E-Commerce-Security-and-Fraud-Protection", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 10 Electronic-Commerce-Payment-Systems", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 11 Order-Fulfillment-Along-the-Supply-Chain", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 12 EC-Strategy", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 13 Implementing EC Systems From Justification to Successful Performance", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 14 E-Commerce-Regulatory-Ethical-And-Social-Environments", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 15 Launching a Successful Online Business and EC Projects", TopicDescription="...", SubjectId="ISC301"},

                    new Topic{TopicName="01 Accounting in Business", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="02 Analyzing and Recording Transactions", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="03 Adjusting Accounts and Preparing Financial Statements", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="04 Completing the Accounting Cycle", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="05 Accounting for Merchandising Operations", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="06 Inventories and Cost of Sales", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="07 Accounting Information Systems", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="08 Cash and Internal Controls", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="09 Accounting for Receivables", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="10 Plant Assets, Natural Resources, and Intangibles", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="11 Current Liabilities and Payroll Accounting", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="12 Accounting for Partnerships", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="13 Accounting for Corporations", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="14 Long-Term Liabilities", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="15 Investments and International Operations", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="16 Reporting the Statement of Cash Flows", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="17 Analysis of Financial Statements", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="18 Managerial Accounting Concepts and Principles", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="19 Job Order Cost Accounting", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="20 Process Cost Accounting", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="21 Cost Allocation and Performance Measurement", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="22 Cost-Volume-Profit Analysis", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="23 Master Budgets and Planning", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="24 Flexible Budgets and Standard Costs", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="25 Capital Budgeting and Managerial Decisions", TopicDescription="...", SubjectId="ACC101"},

                    new Topic{TopicName="CHAPTER 01. DESIGN PATTERNS: ORIGIN AND HISTORY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 02. UML: A QUICK REFERENCE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 03. INTERFACE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 04. ABSTRACT PARENT CLASS", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 05. PRIVATE METHODS", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 06. ACCESSOR METHODS", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 07. CONSTANT DATA MANAGER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 08. IMMUTABLE OBJECT", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 09. MONITOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 10. FACTORY METHOD", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 11. SINGLETON", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 12. ABSTRACT FACTORY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 13. PROTOTYPE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 14. BUILDER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 15. COMPOSITE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 16. ITERATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 17. FLYWEIGHT", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 18. VISITOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 19. DECORATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 20. ADAPTER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 21. CHAIN OF RESPONSIBILITY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 22. FAÇADE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 23. PROXY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 24. BRIDGE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 25. VIRTUAL PROXY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 26. COUNTING PROXY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 27. AGGREGATE ENFORCER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 28. EXPLICIT OBJECT RELEASE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 29. OBJECT CACHE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 30. COMMAND", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 31. MEDIATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 32. MEMENTO", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 33. OBSERVER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 34. INTERPRETER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 35. STATE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 36. STRATEGY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 37. NULL OBJECT", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 38. TEMPLATE METHOD", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 39. OBJECT AUTHENTICATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 40. COMMON ATTRIBUTE REGISTRY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 41. CRITICAL SECTION", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 42. CONSISTENT LOCK ORDER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 43. GUARDED SUSPENSION", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 44. READ-WRITE LOCK", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 45. CASE STUDY: A WEB HOSTING COMPANY", TopicDescription="...", SubjectId="SWD391"},

                    new Topic{TopicName="Chapter 01: What is interaction design?", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 02: Understanding and conceptualizing interaction", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 03: Understanding users", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 04: Designing for collaboration and communication", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 05: Affective aspects", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 06: Interfaces and interactions", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 07: Data gathering", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 08: Data analysis, interpretation and presentation", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 09: The process of interaction design", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 10: Identifying needs and establishing requirements", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 11: Design, prototyping and construction", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 12: Introducing Evaluation", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 13: An evaluation framework", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 14: Usability testing and field studies", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 15: Analytical evaluation", TopicDescription="...", SubjectId="HCI201"},

                    new Topic{TopicName="01. Overview", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="02. Activities_Intents", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="03. AndroidUI", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="04. DynamicUI", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="05. UINotification", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="06. PicturesMenu", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="07. DataPersistent", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="08. DB", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="09. Message_LocalServices", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="10. Android Hardware", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="11. Publish_HTML5", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="12. PhoneGap", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="13. SenchaTouch", TopicDescription="...", SubjectId="PRM391"},

                    new Topic{TopicName="L01-chapter01-ComputerHistory", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L02-chapter02-Software Tools for Techies", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L03-chapter03-Computer Architecture", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L04-chapter04-Number Systems", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L05-chapter05-OS", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L06-chapter06-Network", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L07-chapter07-Internet", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L08-chapter08-Database", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L09-chapter09-Data Structure", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L10-chapter10-File structure", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L11-chapter11-Programming", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L12-chapter12-Software Engineering", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L13-chapter13-Security-Ethics", TopicDescription="...", SubjectId="CSI101"},
                    new Topic{TopicName="L14-Review", TopicDescription="...", SubjectId="CSI101"},

                    new Topic{TopicName="Chapter 01 Basic Concepts and Computer Evolution", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 02 Performance Issues", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 03 A Top-Level View of Computer Function and Interconnection", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 04 Cache Memory", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 05 Internal Memory", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 06 External Memory", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 07 Input/Output", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 08 Operating System Support", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 09 Number Systems", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 10 Computer Arithmetic", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 11 Digital Logic", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 12 Instruction Sets: Characteristics and Functions", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 13 Instruction Sets: Addressing Modes and Formats", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 14 Processor Structure and Function", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 15 Reduced Instruction Set Computers", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 16 Instruction-Level Parallelism and Superscalar Processors", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 17 Parallel Processing", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 18 Multicore Computers", TopicDescription="...", SubjectId="CEA201"},
                    new Topic{TopicName="Chapter 19 General-Purpose Graphic Processing Units", TopicDescription="...", SubjectId="CEA201"},

                };

                context.AddRange(topics);
                context.SaveChanges();

            }

            // Auto seed data if TaskCategories have no data
            if (!context.TaskCategories.Any())
            {
                var taskCategories = new TaskCategory[]{
                    new TaskCategory{TaskType="Self study"},
                    new TaskCategory{TaskType="Exercise / Homework"},
                    new TaskCategory{TaskType="Quiz"},
                    new TaskCategory{TaskType="Assignment / Project"},
                };

                context.AddRange(taskCategories);
                context.SaveChanges();

            }

            // Auto seed data if PlanSemester have no data
            if (!context.PlanSemesters.Any())
            {
                var planSemesters = new PlanSemester[]{
                    new PlanSemester{
                        PlanSemesterName="Happy and pass!",
                        StudentId="SE130720",
                        SemesterId="SU_21",
                        CreateDate=DateTime.UtcNow.AddHours(7),
                        IsComplete=false
                    },
                    new PlanSemester{
                        PlanSemesterName="Let me PASS!!!",
                        StudentId="SE140742",
                        SemesterId="SU_21",
                        CreateDate=DateTime.UtcNow.AddHours(7),
                        IsComplete=false
                    },
                    new PlanSemester{
                        PlanSemesterName="PASS easy!!!",
                        StudentId="SE140329",
                        SemesterId="SU_21",
                        CreateDate=DateTime.UtcNow.AddHours(7),
                        IsComplete=false
                    },
                    new PlanSemester{
                        PlanSemesterName="Happy....",
                        StudentId="SE61637",
                        SemesterId="SU_21",
                        CreateDate=DateTime.UtcNow.AddHours(7),
                        IsComplete=false
                    },
                };

                context.AddRange(planSemesters);
                context.SaveChanges();
            }

            // Auto seed data if PlanSubject have no data
            if (!context.PlanSubjects.Any())
            {
                var planSubjects = new PlanSubject[]{
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "ISC301"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "ACC101"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "SWD391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "HCI201"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "PRM391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 2,
                        SubjectId = "ISC301"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 2,
                        SubjectId = "ACC101"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 2,
                        SubjectId = "SWD391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 2,
                        SubjectId = "HCI201"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 2,
                        SubjectId = "PRM391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 3,
                        SubjectId = "ISC301"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 3,
                        SubjectId = "ACC101"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 3,
                        SubjectId = "SWD391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 3,
                        SubjectId = "HCI201"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 3,
                        SubjectId = "PRM391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 4,
                        SubjectId = "ISC301"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 4,
                        SubjectId = "ACC101"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 4,
                        SubjectId = "SWD391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 4,
                        SubjectId = "HCI201"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 4,
                        SubjectId = "PRM391"
                    },
                };

                context.AddRange(planSubjects);
                context.SaveChanges();
            }

            // Auto seed data if PlanTopic have no data
            if (!context.PlanTopics.Any())
            {
                List<PlanTopic> planTopics = new List<PlanTopic>();

                var planSubject1 = context.PlanSubjects.Where(x => x.PlanSubjectId == 1).FirstOrDefault();
                
                var subject1 = context.Subjects.Where(x => x.SubjectId == planSubject1.SubjectId).FirstOrDefault();

                var topics1 = context.Topics.Where(x => x.SubjectId == subject1.SubjectId).ToArray().OrderBy(x => x.TopicName);
                
                var planSubject2 = context.PlanSubjects.Where(x => x.PlanSubjectId == 2).FirstOrDefault();
                
                var subject2 = context.Subjects.Where(x => x.SubjectId == planSubject2.SubjectId).FirstOrDefault();

                var topics2 = context.Topics.Where(x => x.SubjectId == subject2.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject3 = context.PlanSubjects.Where(x => x.PlanSubjectId == 3).FirstOrDefault();
                
                var subject3 = context.Subjects.Where(x => x.SubjectId == planSubject3.SubjectId).FirstOrDefault();

                var topics3 = context.Topics.Where(x => x.SubjectId == subject3.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject4 = context.PlanSubjects.Where(x => x.PlanSubjectId == 4).FirstOrDefault();
                
                var subject4 = context.Subjects.Where(x => x.SubjectId == planSubject4.SubjectId).FirstOrDefault();

                var topics4 = context.Topics.Where(x => x.SubjectId == subject4.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject5 = context.PlanSubjects.Where(x => x.PlanSubjectId == 5).FirstOrDefault();
                
                var subject5 = context.Subjects.Where(x => x.SubjectId == planSubject5.SubjectId).FirstOrDefault();

                var topics5 = context.Topics.Where(x => x.SubjectId == subject5.SubjectId).ToArray().OrderBy(x => x.TopicName);

                // =============================================================================================================
                var planSubject6 = context.PlanSubjects.Where(x => x.PlanSubjectId == 6).FirstOrDefault();
                
                var subject6 = context.Subjects.Where(x => x.SubjectId == planSubject6.SubjectId).FirstOrDefault();

                var topics6 = context.Topics.Where(x => x.SubjectId == subject6.SubjectId).ToArray().OrderBy(x => x.TopicName);
                
                var planSubject7 = context.PlanSubjects.Where(x => x.PlanSubjectId == 7).FirstOrDefault();
                
                var subject7 = context.Subjects.Where(x => x.SubjectId == planSubject7.SubjectId).FirstOrDefault();

                var topics7 = context.Topics.Where(x => x.SubjectId == subject7.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject8 = context.PlanSubjects.Where(x => x.PlanSubjectId == 8).FirstOrDefault();
                
                var subject8 = context.Subjects.Where(x => x.SubjectId == planSubject8.SubjectId).FirstOrDefault();

                var topics8 = context.Topics.Where(x => x.SubjectId == subject8.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject9 = context.PlanSubjects.Where(x => x.PlanSubjectId == 9).FirstOrDefault();
                
                var subject9 = context.Subjects.Where(x => x.SubjectId == planSubject9.SubjectId).FirstOrDefault();

                var topics9 = context.Topics.Where(x => x.SubjectId == subject9.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject10 = context.PlanSubjects.Where(x => x.PlanSubjectId == 10).FirstOrDefault();
                
                var subject10 = context.Subjects.Where(x => x.SubjectId == planSubject10.SubjectId).FirstOrDefault();

                var topics10 = context.Topics.Where(x => x.SubjectId == subject10.SubjectId).ToArray().OrderBy(x => x.TopicName);

                // =============================================================================================================
                var planSubject11 = context.PlanSubjects.Where(x => x.PlanSubjectId == 11).FirstOrDefault();
                
                var subject11 = context.Subjects.Where(x => x.SubjectId == planSubject11.SubjectId).FirstOrDefault();

                var topics11 = context.Topics.Where(x => x.SubjectId == subject11.SubjectId).ToArray().OrderBy(x => x.TopicName);
                
                var planSubject12 = context.PlanSubjects.Where(x => x.PlanSubjectId == 12).FirstOrDefault();
                
                var subject12 = context.Subjects.Where(x => x.SubjectId == planSubject12.SubjectId).FirstOrDefault();

                var topics12 = context.Topics.Where(x => x.SubjectId == subject12.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject13 = context.PlanSubjects.Where(x => x.PlanSubjectId == 13).FirstOrDefault();
                
                var subject13 = context.Subjects.Where(x => x.SubjectId == planSubject13.SubjectId).FirstOrDefault();

                var topics13 = context.Topics.Where(x => x.SubjectId == subject13.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject14 = context.PlanSubjects.Where(x => x.PlanSubjectId == 14).FirstOrDefault();
                
                var subject14 = context.Subjects.Where(x => x.SubjectId == planSubject14.SubjectId).FirstOrDefault();

                var topics14 = context.Topics.Where(x => x.SubjectId == subject14.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject15 = context.PlanSubjects.Where(x => x.PlanSubjectId == 15).FirstOrDefault();
                
                var subject15 = context.Subjects.Where(x => x.SubjectId == planSubject15.SubjectId).FirstOrDefault();

                var topics15 = context.Topics.Where(x => x.SubjectId == subject15.SubjectId).ToArray().OrderBy(x => x.TopicName);

                // ================================================================================================================
                var planSubject16 = context.PlanSubjects.Where(x => x.PlanSubjectId == 16).FirstOrDefault();
                
                var subject16 = context.Subjects.Where(x => x.SubjectId == planSubject16.SubjectId).FirstOrDefault();

                var topics16 = context.Topics.Where(x => x.SubjectId == subject16.SubjectId).ToArray().OrderBy(x => x.TopicName);
                
                var planSubject17 = context.PlanSubjects.Where(x => x.PlanSubjectId == 17).FirstOrDefault();
                
                var subject17 = context.Subjects.Where(x => x.SubjectId == planSubject17.SubjectId).FirstOrDefault();

                var topics17 = context.Topics.Where(x => x.SubjectId == subject17.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject18 = context.PlanSubjects.Where(x => x.PlanSubjectId == 18).FirstOrDefault();
                
                var subject18 = context.Subjects.Where(x => x.SubjectId == planSubject18.SubjectId).FirstOrDefault();

                var topics18 = context.Topics.Where(x => x.SubjectId == subject18.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject19 = context.PlanSubjects.Where(x => x.PlanSubjectId == 19).FirstOrDefault();
                
                var subject19 = context.Subjects.Where(x => x.SubjectId == planSubject19.SubjectId).FirstOrDefault();

                var topics19 = context.Topics.Where(x => x.SubjectId == subject19.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject20 = context.PlanSubjects.Where(x => x.PlanSubjectId == 20).FirstOrDefault();
                
                var subject20 = context.Subjects.Where(x => x.SubjectId == planSubject20.SubjectId).FirstOrDefault();

                var topics20 = context.Topics.Where(x => x.SubjectId == subject20.SubjectId).ToArray().OrderBy(x => x.TopicName);                

                if(planSubject1 is not null){
                    foreach (var item in topics1)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject1.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }                 

                if(planSubject2 is not null){
                    foreach (var item in topics2)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject2.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject3 is not null){
                    foreach (var item in topics3)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject3.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject4 is not null){
                    foreach (var item in topics4)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject4.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                } 

                if(planSubject5 is not null){
                    foreach (var item in topics5)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject5.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                // ======================================================================================
                if(planSubject6 is not null){
                    foreach (var item in topics6)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject6.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }                 

                if(planSubject7 is not null){
                    foreach (var item in topics7)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject7.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject8 is not null){
                    foreach (var item in topics8)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject8.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject9 is not null){
                    foreach (var item in topics9)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject9.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                } 

                if(planSubject10 is not null){
                    foreach (var item in topics10)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject10.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                // ===============================================================================================
                if(planSubject11 is not null){
                    foreach (var item in topics11)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject11.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }                 

                if(planSubject12 is not null){
                    foreach (var item in topics12)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject12.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject13 is not null){
                    foreach (var item in topics13)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject13.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject14 is not null){
                    foreach (var item in topics14)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject14.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                } 

                if(planSubject15 is not null){
                    foreach (var item in topics15)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject15.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }
                //=======================================================================================================
                if(planSubject16 is not null){
                    foreach (var item in topics16)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject16.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }                 

                if(planSubject17 is not null){
                    foreach (var item in topics17)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject17.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject18 is not null){
                    foreach (var item in topics18)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject18.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject19 is not null){
                    foreach (var item in topics19)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject19.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                } 

                if(planSubject20 is not null){
                    foreach (var item in topics20)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject20.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }


                context.AddRange(planTopics);
                context.SaveChanges();

            }

            // Auto seed data if Task have no data
            if (!context.Tasks.Any()){
                var plantopics = context.PlanTopics.ToArray();

                List<Task> tasks = new List<Task>();

                foreach (var item in plantopics)
                {
                    var task1 = new Task{
                        TaskDescription = "Read at home " + item.Topic.TopicName,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        EstimateTime = 2,
                        EffortTime = 1,
                        DueDate = DateTime.UtcNow.AddHours(10),
                        Priority = 0,
                        IsComplete = false,
                        PlanTopicId = item.PlanTopicId,
                        TaskCategoryId = 1
                    };

                    var task2 = new Task{
                        TaskDescription = "Do exercise of " + item.Topic.TopicName,
                        CreateDate = DateTime.UtcNow.AddHours(11),
                        EstimateTime = 2,
                        EffortTime = 1,
                        DueDate = DateTime.UtcNow.AddHours(14),
                        Priority = 0,
                        IsComplete = false,
                        PlanTopicId = item.PlanTopicId,
                        TaskCategoryId = 2
                    };

                    var task3 = new Task{
                        TaskDescription = "Make quiz of " + item.Topic.TopicName,
                        CreateDate = DateTime.UtcNow.AddHours(15),
                        EstimateTime = 2,
                        EffortTime = 1,
                        DueDate = DateTime.UtcNow.AddHours(19),
                        Priority = 1,
                        IsComplete = false,
                        PlanTopicId = item.PlanTopicId,
                        TaskCategoryId = 3
                    };

                    tasks.Add(task1);
                    tasks.Add(task2);
                    tasks.Add(task3);
                }

                context.AddRange(tasks);
                context.SaveChanges();
            }
        }
    }
}
