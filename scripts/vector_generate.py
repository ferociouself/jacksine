import math

outfile_name = 'circle.txt'
width = 160
height = 90

def evalX(r, c, width, height):
    #x = -math.cos((r * 1.0 / width) * 2 * math.pi)
    x = (r - height / 2) / height
    return x
    
def evalY(r, c, width, height):
    #y = math.sin((c * 1.0 / height) * 2 * math.pi)
    y = (c - width / 2) / height
    return y

with open(outfile_name, 'w') as fout:
    nums = []
    for r in range(height):
        linenums = []
        for c in range(width):
            linenums.append(evalX(r,c,width,height))
            linenums.append(evalY(r,c,width,height))
        nums.append(linenums)
    fout.write('\n'.join([' '.join([str(num) for num in lst]) for lst in nums]))