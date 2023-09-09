
namespace CWUtils
{
    public enum ComparisonType{
        equal,
        lessthan,
        morethan,
        lessthanorequal,
        morethanorequal
    }
    public static class Comparisons{
        public static bool EvalComparison (ComparisonType type, int val1, int val2){
            if(type == ComparisonType.equal){
                if(val1 == val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthan){
                if(val1 < val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethan){
                if(val1 > val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthanorequal){
                if(val1 <= val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethanorequal){
                if(val1 >= val2){
                    return true;
                }
            }
            return false;
        }
        public static bool EvalComparison (ComparisonType type, float val1, float val2){
            if(type == ComparisonType.equal){
                if(val1 == val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthan){
                if(val1 < val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethan){
                if(val1 > val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthanorequal){
                if(val1 <= val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethanorequal){
                if(val1 >= val2){
                    return true;
                }
            }
            return false;
        }
        public static bool EvalComparison(ComparisonType type, float val1, int val2){
            if(type == ComparisonType.equal){
                if(val1 == val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthan){
                if(val1 < val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethan){
                if(val1 > val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthanorequal){
                if(val1 <= val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethanorequal){
                if(val1 >= val2){
                    return true;
                }
            }
            return false;
        }
        public static bool EvalComparison (ComparisonType type, int val1, float val2){
            if(type == ComparisonType.equal){
                if(val1 == val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthan){
                if(val1 < val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethan){
                if(val1 > val2){
                    return true;
                }
            }
            if(type == ComparisonType.lessthanorequal){
                if(val1 <= val2){
                    return true;
                }
            }
            if(type == ComparisonType.morethanorequal){
                if(val1 >= val2){
                    return true;
                }
            }
            return false;
        }
    
    }
}
